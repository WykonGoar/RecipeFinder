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

namespace RecipeFinderDatabase
{
    public partial class NewIngredient : Form
    {
        private RecipeFinderDatabase mForm;
        private int mRecipeId;
        private DatabaseConnection mDatabaseConnection;

        public NewIngredient(RecipeFinderDatabase form, int recipeId)
        {
            InitializeComponent();

            mDatabaseConnection = new DatabaseConnection();
            mForm = form;
            mRecipeId = recipeId;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            Ingredient ingredient = new Ingredient();

            ingredient.RecipeId = mRecipeId;
            ingredient.Name = tbName.Text;
            ingredient.Amount = tbAmount.Text;
            ingredient.Measure = tbMeasure.Text;

            bool successfull = true;
            try
            {
                successfull = mDatabaseConnection.ExecuteNonReturnQuery(ingredient.GetInsertQuery());
            }
            catch (SqlException ex)
            {
                successfull = false;
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (successfull)
            {
                MessageBox.Show("Het ingredient is toegevoegd.", "Toevoegen gelukt.");
                mForm.ReloadRecipes();
                this.Close();
            }
        }
    }
}
