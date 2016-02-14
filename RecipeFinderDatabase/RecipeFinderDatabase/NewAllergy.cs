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
    public partial class NewAllergy : Form
    {
        private RecipeFinderDatabase mForm;
        private DatabaseConnection mDatabaseConnection;

        public NewAllergy(RecipeFinderDatabase form)
        {
            InitializeComponent();

            mDatabaseConnection = new DatabaseConnection();
            mForm = form;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            Allergy allergy = new Allergy();

            allergy.Name = tbName.Text;

            bool successfull = true;
            try
            {
                successfull = mDatabaseConnection.ExecuteNonReturnQuery(allergy.GetInsertQuery());
            }
            catch (SqlException ex)
            {
                successfull = false;
                MessageBox.Show(ex.Message, "Error:" + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (successfull)
            {
                MessageBox.Show("Het allergy is toegevoegd.", "Toevoegen gelukt.");
                mForm.ReloadAllergies();
                this.Close();
            }
        }
    }
}
