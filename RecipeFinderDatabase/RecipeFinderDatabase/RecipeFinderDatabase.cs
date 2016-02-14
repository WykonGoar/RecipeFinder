using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecipeFinderDatabase.Models;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace RecipeFinderDatabase
{
    public partial class RecipeFinderDatabase : Form
    {
        private DatabaseConnection mDatabaseConnection;
        private int currentRecipeId = -1;
        private List<Allergy> mAllergies;

        public RecipeFinderDatabase()
        {
            InitializeComponent();

            mDatabaseConnection = new DatabaseConnection();

            lbIngredients.DisplayMember = "Name";
            lbAllergies.DisplayMember = "Name";
            lbAllergiesRecipes.DisplayMember = "Name";
            cbbAllergy.DisplayMember = "Name";
            lbRecipes.DisplayMember = "Title";

            ReloadRecipes();
            ReloadAllergies();
        }

        public void ReloadAllergies()
        {
            mAllergies = mDatabaseConnection.GetAllAllergies();

            lbAllergies.Items.Clear();            
            lbAllergies.Items.AddRange(mAllergies.ToArray());            
        }

        public void ReloadRecipes(){
            List<Recipe> mRecipes = mDatabaseConnection.GetAllRecipes();
            lbRecipes.Items.Clear();
            lbRecipes.Items.AddRange(mRecipes.ToArray());

            if (currentRecipeId != -1)
            {
                lbIngredients.Items.Clear();
                foreach(Recipe recipe in mRecipes)
                {
                    if (recipe.Id == currentRecipeId)
                    {
                        lbIngredients.Items.AddRange(recipe.Ingredients.ToArray());
                        lbAllergiesRecipes.Items.AddRange(recipe.Allergies.ToArray());
                    }
                }

                ReloadAllergiesRecipes();
            }
        }

        public void ReloadAllergiesRecipes()
        {
            List<Recipe> mRecipes = mDatabaseConnection.GetAllRecipes();

            if (currentRecipeId != -1)
            {
                cbbAllergy.Items.Clear();
                lbAllergiesRecipes.Items.Clear();
                foreach(Recipe recipe in mRecipes)
                {
                    if (recipe.Id == currentRecipeId)
                    {
                        foreach(Allergy allergy in mAllergies)
                        {
                            bool noAllergy = true;
                            foreach (AllergiesRecipes allergyRecipe in recipe.Allergies)
                            {
                                if (allergyRecipe.AllergyId == allergy.Id)
                                {
                                    noAllergy = false;
                                    lbAllergiesRecipes.Items.Add(allergyRecipe);
                                }
                            }

                            if (noAllergy)
                                cbbAllergy.Items.Add(allergy);
                        }
                    }
                }
            }            
        }

        private void lbRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recipe selectedRecipe = (Recipe)lbRecipes.SelectedItem;

            if (selectedRecipe == null)
                return;

            tbTitle.Text = selectedRecipe.Title;
            tbBook.Text = selectedRecipe.Book;
            nudPage.Value = selectedRecipe.Page;
            tbKitchen.Text = selectedRecipe.Kitchen;
            cbbCourse.Text = selectedRecipe.Course;
            nudMaxPreperationTime.Value = selectedRecipe.MaxPreperationTime;
            nudPersons.Value = selectedRecipe.Persons;
            cbFavorite.Checked = selectedRecipe.Favorite;
            cbHide.Checked = selectedRecipe.Hide;

            lbIngredients.Items.Clear();
            lbIngredients.Items.AddRange(selectedRecipe.Ingredients.ToArray());

            ReloadAllergiesRecipes();

            currentRecipeId = selectedRecipe.Id;
            tcEditor.Enabled = true;
        }

        private void lbIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ingredient selectedIngredient = (Ingredient) lbIngredients.SelectedItem;

            if (selectedIngredient == null)
                return;

            tbName.Text = selectedIngredient.Name;
            tbAmount.Text = selectedIngredient.Amount;
            tbMeasure.Text = selectedIngredient.Measure;

            tbName.Enabled = true;
            tbAmount.Enabled = true;
            tbMeasure.Enabled = true;
            bSaveIngredient.Enabled = true;
        }

        private void bSaveRecipe_Click(object sender, EventArgs e)
        {
            Recipe selectedRecipe = (Recipe)lbRecipes.SelectedItem;

            selectedRecipe.Title = tbTitle.Text;
            selectedRecipe.Book = tbBook.Text;
            selectedRecipe.Page = (int)nudPage.Value;
            selectedRecipe.Kitchen = tbKitchen.Text;
            selectedRecipe.Course = cbbCourse.Text;
            selectedRecipe.MaxPreperationTime = (int)nudMaxPreperationTime.Value;
            selectedRecipe.Persons = (int)nudPersons.Value;
            selectedRecipe.Favorite = cbFavorite.Checked;
            selectedRecipe.Hide = cbHide.Checked;

            bool successful = true;
            try
            {
                successful = mDatabaseConnection.ExecuteNonReturnQuery(selectedRecipe.GetUpdateQuery());
            }
            catch (SqlException ex)
            {
                successful = false;
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(successful)
                MessageBox.Show("Het recept is aangepast.", "Aanpassing gelukt.");
        }

        private void bSaveIngredient_Click(object sender, EventArgs e)
        {
            Ingredient selectedIngredient = (Ingredient)lbIngredients.SelectedItem;

            selectedIngredient.Name = tbName.Text;
            selectedIngredient.Amount = tbAmount.Text;
            selectedIngredient.Measure = tbMeasure.Text;

            bool successful = true;
            try
            {
                successful = mDatabaseConnection.ExecuteNonReturnQuery(selectedIngredient.GetUpdateQuery());
            }
            catch (SqlException ex)
            {
                successful = false;
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (successful)
                MessageBox.Show("Het recept is aangepast.", "Aanpassing gelukt.");
        }

        private void bNewIngredient_Click(object sender, EventArgs e)
        {
            NewIngredient newIngredientForm = new NewIngredient(this, currentRecipeId);
            newIngredientForm.ShowDialog();
        }

        private void bDeleteIngredient_Click(object sender, EventArgs e)
        {
            Ingredient selectedIngredient = (Ingredient)lbIngredients.SelectedItem;
            OleDbCommand[] commands = selectedIngredient.GetDeleteQuerys();
            
            try
            {
                bool successfull1 = mDatabaseConnection.ExecuteNonReturnQuery(commands[0]);
                if (successfull1)
                {
                    bool successfull2 = mDatabaseConnection.ExecuteNonReturnQuery(commands[1]);
                    if (successfull2)
                    {
                        MessageBox.Show("Het ingredient is verwijderd.", "Verwijderen gelukt.");

                        tbName.Text = String.Empty;
                        tbAmount.Text = String.Empty;
                        tbMeasure.Text = String.Empty;

                        tbName.Enabled = false;
                        tbAmount.Enabled = false;
                        tbMeasure.Enabled = false;
                        bSaveIngredient.Enabled = false;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ReloadRecipes();
        }

        private void bDeleteRecipe_Click(object sender, EventArgs e)
        {
            Recipe selectedRecipe = (Recipe)lbRecipes.SelectedItem;
            OleDbCommand[] commands = selectedRecipe.GetDeleteQuerys();
            
            try
            {
                bool successfull1 = mDatabaseConnection.ExecuteNonReturnQuery(commands[0]);

                if (successfull1)
                {
                    bool successfull2 = mDatabaseConnection.ExecuteNonReturnQuery(commands[1]);
                    if (successfull2)
                    {
                        ReloadRecipes();
                        ClearRecipeValues();
                        currentRecipeId = -1;
                        MessageBox.Show("Het recept is verwijderd.", "Verwijderen gelukt.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearRecipeValues()
        {
            tbTitle.Text = "";
            tbBook.Text = "";
            nudPage.Value = 0;
            tbKitchen.Text = "";
            cbbCourse.Text = "";
            nudMaxPreperationTime.Value = 0;
            nudPersons.Value = 1;
            cbFavorite.Checked = false;
            cbHide.Checked = false;

            lbIngredients.Items.Clear();
            tcEditor.Enabled = false;
        }


        private void bNewRecipe_Click(object sender, EventArgs e)
        {
            NewRecipe newRecipeForm = new NewRecipe(this);
            newRecipeForm.ShowDialog();
        }

        private void importeerReceptenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IORecipes mIORecipes = new IORecipes();
            bool succesfull = mIORecipes.ImportRecipes();
            if (succesfull)
                MessageBox.Show("De recepten zijn geïmporteerd.", "Importeren gelukt.");
        }

        private void exporteerReceptenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IORecipes mIORecipes = new IORecipes();
            bool succesfull = mIORecipes.ExportRecipes();
            if(succesfull)
                MessageBox.Show("De recepten zijn geëxporteerd.", "Exporteren gelukt.");
        }

        private void bAddAllergieRecipe_Click(object sender, EventArgs e)
        {
            Allergy allergy = (Allergy) cbbAllergy.SelectedItem;

            AllergiesRecipes allergyRecipe = new AllergiesRecipes();
            allergyRecipe.RecipeId = currentRecipeId;
            allergyRecipe.AllergyId = allergy.Id;

            bool successfull = true;
            try
            {
                successfull = mDatabaseConnection.ExecuteNonReturnQuery(allergyRecipe.GetInsertQuery());
            }
            catch (SqlException ex)
            {
                successfull = false;
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (successfull)
            {
                ReloadAllergiesRecipes();
            }
        }

        private void bDeleteRecipeAllergie_Click(object sender, EventArgs e)
        {
            AllergiesRecipes selectedAllergy = (AllergiesRecipes)lbAllergies.SelectedItem;
            OleDbCommand[] commands = selectedAllergy.GetDeleteQuerys();

            try
            {
                bool successfull1 = mDatabaseConnection.ExecuteNonReturnQuery(commands[0]);

                if (successfull1)
                {
                    bool successfull2 = mDatabaseConnection.ExecuteNonReturnQuery(commands[1]);
                    if (successfull2)
                    {
                        ReloadAllergiesRecipes();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bNewAllergy_Click(object sender, EventArgs e)
        {
            NewAllergy newAllergyForm = new NewAllergy(this);
            newAllergyForm.ShowDialog();
        }

        private void bDeleteAllergy_Click(object sender, EventArgs e)
        {
            Allergy selectedAllergy = (Allergy)lbAllergies.SelectedItem;
            OleDbCommand[] commands = selectedAllergy.GetDeleteQuerys();

            try
            {
                bool successfull1 = mDatabaseConnection.ExecuteNonReturnQuery(commands[0]);

                if (successfull1)
                {
                    bool successfull2 = mDatabaseConnection.ExecuteNonReturnQuery(commands[1]);
                    if (successfull2)
                    {
                        ReloadAllergies();
                        MessageBox.Show("Het allergy is verwijderd.", "Verwijderen gelukt.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
