using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace RecipeFinderDatabase.Models
{
    public class IORecipes
    {
        private DatabaseConnection mDatabaseConnection;
        private static string EXPORT_FILE_NAME = "ImportRecipes.txt";

        public IORecipes() 
        {
            mDatabaseConnection = new DatabaseConnection();
        }

        public bool ExportRecipes()
        {
            bool succesfull = true;
            string fileLocation = GetSaveFileDialog();

            if (fileLocation == null)
                return false;

            fileLocation = CheckFileName(fileLocation);

            List<Recipe> recipeList = mDatabaseConnection.GetAllRecipes();
            List<DeletedValue> deletedValueList = mDatabaseConnection.GetAllDeletedValues();

            StreamWriter mStreamWriter = null ;
            try
            {
                mStreamWriter = new StreamWriter(fileLocation);
                foreach (Recipe recipe in recipeList)
                {
                    string updateRecipeQuery = recipe.GetExportString();
                    mStreamWriter.WriteLine(updateRecipeQuery);

                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        string updateIngredientQuery = ingredient.GetExportString();
                        mStreamWriter.WriteLine(updateIngredientQuery);
                    }
                }

                foreach (DeletedValue deletedValue in deletedValueList)
                {
                    mStreamWriter.WriteLine(deletedValue.GetDeleteQuery());
                }
            }
            catch(IOException ex)
            {
                succesfull = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mStreamWriter.Close();
            }

            return succesfull;
        }

        public bool ImportRecipes()
        {
            bool succesful = true;
            string fileLocation = GetOpenFileDialog();
            
            if (fileLocation == null)
                return false;

            StreamReader mStreamReader = null;
            try
            {
                mStreamReader = new StreamReader(fileLocation);

                while (!mStreamReader.EndOfStream)
                {
                    string query = mStreamReader.ReadLine();
                    
                    //SqlCommand mSqlCommand = new SqlCommand(query);                    
                    //bool updated = mDatabaseConnection.ExecuteNonReturnQuery(mSqlCommand);

                    OleDbCommand command = new OleDbCommand(query);
                    bool updated = mDatabaseConnection.ExecuteNonReturnQuery(command);

                    if (!updated)
                    {
                        string insertQuery = String.Empty;

                        if(query.Contains("UPDATE recipes SET"))
                        {
                            insertQuery = "INSERT INTO recipes(";
                            query = query.Replace("UPDATE recipes SET ", String.Empty);

                            insertQuery += ConvertUpdateToInsertQuery(query);
                        }
                        else
                        {
                            insertQuery = "INSERT INTO ingredients(";
                            query = query.Replace("UPDATE ingredients SET ", String.Empty);

                            insertQuery += ConvertUpdateToInsertQuery(query);
                        }

                        //SqlCommand newSqlCommand = new SqlCommand(insertQuery);
                        //mDatabaseConnection.ExecuteNonReturnQuery(newSqlCommand);

                        OleDbCommand newCommand = new OleDbCommand(insertQuery);
                        mDatabaseConnection.ExecuteNonReturnQuery(newCommand);
                    }

                }
            }
            catch(IOException ex)
            {
                mStreamReader.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return succesful;
        }

        private string ConvertUpdateToInsertQuery(string updateQuery)
        {
            string idUpdateText = updateQuery.Substring(updateQuery.LastIndexOf("WHERE") - 1);
            string id = idUpdateText.Substring(idUpdateText.IndexOf("=") +1).Replace(";", String.Empty);

            updateQuery = updateQuery.Replace(idUpdateText, String.Empty);

            string columnValues = "_id";
            string values = id;

            string[] updateBoxes = updateQuery.Split(',');
            for(int i = 0; i < updateBoxes.Length; i++)
            {
                string[] columnValue = updateBoxes[i].Split('=');
                columnValues += ", " + columnValue[0].Replace(" ", String.Empty);

                values += ", " + columnValue[1];

                if(columnValue.Length > 2)
                {
                    for(int c = 1; c < columnValues.Length; c++)
                    {
                        values += columnValue[c];
                    }
                }
            }

            String insertQuery = columnValues + ") VALUES (" + values + ");";
            return insertQuery;
        }

        private string CheckFileName(string chosenName)
        {
            string name = chosenName.Substring(chosenName.LastIndexOf('\\') + 1);
            if (EXPORT_FILE_NAME != name)
            {
                MessageBox.Show("Het bestandsnaam word gezet naar \"" + EXPORT_FILE_NAME + "\" omdat de app deze naam gebruikt.", "Naam verandering", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return chosenName.Substring(0, chosenName.LastIndexOf("\\") + 1) + EXPORT_FILE_NAME;
            }

            return chosenName;
        }

        private string GetSaveFileDialog()
        {
            SaveFileDialog mSaveFileDialog = new SaveFileDialog();
            mSaveFileDialog.ValidateNames = true;
            mSaveFileDialog.Filter = "Text Files | *.txt";
            mSaveFileDialog.FileName = EXPORT_FILE_NAME;
            mSaveFileDialog.CheckPathExists = true;
            DialogResult result = mSaveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return mSaveFileDialog.FileName;
            }

            return null;
        }

        private string GetOpenFileDialog()
        {
            OpenFileDialog mOpenFileDialog = new OpenFileDialog();
            mOpenFileDialog.Filter = "Text Files | *.txt";
            mOpenFileDialog.CheckFileExists = true;
            DialogResult result = mOpenFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return mOpenFileDialog.FileName;
            }

            return null;
        }


    }
}
