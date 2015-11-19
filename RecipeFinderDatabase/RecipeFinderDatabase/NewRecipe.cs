using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RecipeFinderDatabase.Models;

namespace RecipeFinderDatabase
{
    public partial class NewRecipe : Form
    {
        private RecipeFinderDatabase mForm;
        private DatabaseConnection mDatabaseConnection;

        public NewRecipe(RecipeFinderDatabase form)
        {
            InitializeComponent();

            mDatabaseConnection = new DatabaseConnection();
            mForm = form;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            Recipe mRecipe = new Recipe();

            mRecipe.Title = tbTitle.Text;
            mRecipe.Book = tbBook.Text;
            mRecipe.Page = (int)nudPage.Value;

            if (tbKitchen.Text != String.Empty)
                mRecipe.Kitchen = tbKitchen.Text;
            else
                mRecipe.Kitchen = "Geen keuken";

            mRecipe.Course = cbbCourse.Text;
            mRecipe.MaxPreperationTime = (int)nudMaxPreperationTime.Value;
            mRecipe.Persons = (int)nudPersons.Value;
            mRecipe.Favorite = cbFavorite.Checked;
            mRecipe.LactoseFree = cbLacoseFree.Checked;
            mRecipe.GlutenFree = cbGlutenFree.Checked;
            mRecipe.Hide = cbHide.Checked;

            bool successfull = true;
            try
            {
                successfull = mDatabaseConnection.ExecuteNonReturnQuery(mRecipe.GetInsertQuery());
            }
            catch (SqlException ex)
            {
                successfull = false;
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (successfull)
            {
                MessageBox.Show("Het recept is toegevoegd.", "Toevoegen gelukt.");
                mForm.ReloadRecipes();
                this.Close();
            }
        }
    }
}
