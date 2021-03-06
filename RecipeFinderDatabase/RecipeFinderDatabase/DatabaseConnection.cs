﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

using RecipeFinderDatabase.Models;

namespace RecipeFinderDatabase
{
    public class DatabaseConnection
    {
        //private SqlConnection mSqlConnection;
        private OleDbConnection mConnection;
        private string mDatabaseLocation;

        private string mConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        public DatabaseConnection()
        {
            //string dataSource = @"""D:/Documents/Visual Studio 2013/Projects/ResourceFinderDatabase/ResourceFinderDatabase\RecipeFinderDB.accdb";
           if (Properties.Settings.Default.RecipeFinderDBConnectionString == String.Empty)
                SetDatabaseLocation();
            else
                mDatabaseLocation = Properties.Settings.Default.RecipeFinderDBConnectionString;


                mConnectionString += mDatabaseLocation;
            //mSqlConnection = new SqlConnection(Properties.Settings.Default.RecipeFinderDBConnectionString);
            mConnection = new OleDbConnection(mConnectionString);
        }

        private void SetDatabaseLocation()
        {
            MessageBox.Show("Kies de database file die gebruikt moet worden.", "Kies database");

            OpenFileDialog mOpenFileDialog = new OpenFileDialog();
            mOpenFileDialog.Filter = "Access file | *.accdb";
            mOpenFileDialog.CheckFileExists = true;
            mOpenFileDialog.Title = "Kies databse";
            DialogResult result = mOpenFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                mDatabaseLocation = mOpenFileDialog.FileName;
                Properties.Settings.Default.RecipeFinderDBConnectionString = mDatabaseLocation;
                Properties.Settings.Default.Save();
                return;
            }

            Environment.Exit(0);
        }

        //public bool ExecuteNonReturnQuery(SqlCommand mSqlCommand)
        public bool ExecuteNonReturnQuery(OleDbCommand command)
        {
            bool succesfull = true;

            /*
            mSqlConnection.Open();
            mSqlCommand.Connection = mSqlConnection;
            int affectedRows = mSqlCommand.ExecuteNonQuery();            
            mSqlConnection.Close();
            */

            mConnection.Open();
            command.Connection = mConnection;
            int affectedRows = command.ExecuteNonQuery();
            mConnection.Close();

            if (affectedRows == 0)
                succesfull = false;
            
            return succesfull;
        }

        public List<Recipe> GetAllRecipes()
        {
            string query = "SELECT * FROM recipes ORDER BY title";
            //SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            OleDbCommand command = new OleDbCommand(query, mConnection);

            //SqlDataReader mSqlDataReader = null;
            OleDbDataReader dataReader = null;
            List<Recipe> recipeList = new List<Recipe>();
            try
            {
                //mSqlConnection.Open();
                //mSqlDataReader = mSqlCommand.ExecuteReader();

                mConnection.Open();
                dataReader = command.ExecuteReader();

                // Check is the reader has any rows at all before starting to read.
                //if (mSqlDataReader.HasRows)
                if(dataReader.HasRows)
                {
                    // Read advances to the next row.
                    //while (mSqlDataReader.Read())
                    while(dataReader.Read())
                    {
                        Recipe recipe = new Recipe();

                        recipe.Id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        recipe.Book = dataReader.GetString(dataReader.GetOrdinal("book"));
                        recipe.Page = dataReader.GetInt32(dataReader.GetOrdinal("page"));
                        recipe.Kitchen = dataReader.GetString(dataReader.GetOrdinal("kitchen"));
                        recipe.Course = dataReader.GetString(dataReader.GetOrdinal("course"));
                        recipe.Title = dataReader.GetString(dataReader.GetOrdinal("title"));
                        recipe.MaxPreperationTime = dataReader.GetInt32(dataReader.GetOrdinal("maxPreperationTime"));
                        recipe.Persons = dataReader.GetInt32(dataReader.GetOrdinal("persons"));
                        recipe.FavoriteInt = dataReader.GetInt32(dataReader.GetOrdinal("favorite"));
                        recipe.HideInt = dataReader.GetInt32(dataReader.GetOrdinal("hide"));
                        
                        recipeList.Add(recipe);
                    }
                }
            }
            //catch (SqlException ex)
            catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //mSqlDataReader.Close();
                //mSqlConnection.Close();

                dataReader.Close();
                mConnection.Close();
            }

            foreach(Recipe recipe in recipeList)
            {
                recipe.Ingredients = GetAllIngredients(recipe.Id);
                recipe.Allergies = GetAllAllergiesFromRecipe(recipe.Id);
            }

            return recipeList;
        }

        private List<Ingredient> GetAllIngredients(int recipeId)
        {
            string query = "SELECT * FROM ingredients WHERE recipeId = @P0 ORDER BY name";
            //SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            //mSqlCommand.Parameters.AddWithValue("P0", recipeId);

            OleDbCommand command = new OleDbCommand(query, mConnection);
            command.Parameters.AddWithValue("P0", recipeId);

            //SqlDataReader mSqlDataReader = null;
            OleDbDataReader dataReader = null; 
            
            List<Ingredient> ingredientList = new List<Ingredient>();
            try
            {
                //mSqlConnection.Open();
                //mSqlDataReader = mSqlCommand.ExecuteReader();

                mConnection.Open();
                dataReader = command.ExecuteReader();

                // Check is the reader has any rows at all before starting to read.
                //if (mSqlDataReader.HasRows)
                if (dataReader.HasRows)
                {
                    // Read advances to the next row.
                    //while (mSqlDataReader.Read())
                    while (dataReader.Read())
                    {
                        Ingredient ingredient = new Ingredient();
                        
                        ingredient.Id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        ingredient.RecipeId = dataReader.GetInt32(dataReader.GetOrdinal("recipeId"));
                        ingredient.Name = dataReader.GetString(dataReader.GetOrdinal("name"));
                        ingredient.Amount = dataReader.GetString(dataReader.GetOrdinal("amount"));
                        ingredient.Measure = dataReader.GetString(dataReader.GetOrdinal("measure"));

                        ingredientList.Add(ingredient);
                    }
                }
            }
            //catch (SqlException ex)
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //mSqlDataReader.Close();
                //mSqlConnection.Close();

                dataReader.Close();
                mConnection.Close();
            }

            return ingredientList;
        }

        private List<AllergiesRecipes> GetAllAllergiesFromRecipe(int recipeId)
        {
            string query = "SELECT a.id, a.recipeId, a.allergyId, g.name FROM allergiesrecipes a RIGHT JOIN allergies g ON a.allergyId = g.id WHERE a.recipeId = @P0 ORDER BY g.name";
            //SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            //mSqlCommand.Parameters.AddWithValue("P0", recipeId);

            OleDbCommand command = new OleDbCommand(query, mConnection);
            command.Parameters.AddWithValue("P0", recipeId);

            //SqlDataReader mSqlDataReader = null;
            OleDbDataReader dataReader = null;

            List<AllergiesRecipes> allergyList = new List<AllergiesRecipes>();
            try
            {
                //mSqlConnection.Open();
                //mSqlDataReader = mSqlCommand.ExecuteReader();

                mConnection.Open();
                dataReader = command.ExecuteReader();

                // Check is the reader has any rows at all before starting to read.
                //if (mSqlDataReader.HasRows)
                if (dataReader.HasRows)
                {
                    // Read advances to the next row.
                    //while (mSqlDataReader.Read())
                    while (dataReader.Read())
                    {
                        AllergiesRecipes allergy = new AllergiesRecipes();

                        allergy.Id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        allergy.RecipeId = dataReader.GetInt32(dataReader.GetOrdinal("recipeId"));
                        allergy.AllergyId = dataReader.GetInt32(dataReader.GetOrdinal("allergyId"));
                        allergy.Name = dataReader.GetString(dataReader.GetOrdinal("name"));

                        allergyList.Add(allergy);
                    }
                }
            }
            //catch (SqlException ex)
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //mSqlDataReader.Close();
                //mSqlConnection.Close();

                dataReader.Close();
                mConnection.Close();
            }

            return allergyList;
        }

        public List<Allergy> GetAllAllergies()
        {
            string query = "SELECT * FROM allergies";
            //SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

            OleDbCommand command = new OleDbCommand(query, mConnection);

            //SqlDataReader mSqlDataReader = null;
            OleDbDataReader dataReader = null;

            List<Allergy> allergyList = new List<Allergy>();
            try
            {
                //mSqlConnection.Open();
                //mSqlDataReader = mSqlCommand.ExecuteReader();

                mConnection.Open();
                dataReader = command.ExecuteReader();

                // Check is the reader has any rows at all before starting to read.
                //if (mSqlDataReader.HasRows)
                if (dataReader.HasRows)
                {
                    // Read advances to the next row.
                    //while (mSqlDataReader.Read())
                    while (dataReader.Read())
                    {
                        Allergy allergy = new Allergy();

                        int id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                        string name = dataReader.GetString(dataReader.GetOrdinal("name"));

                        allergy.Id = id;
                        allergy.Name = name;

                        allergyList.Add(allergy);
                    }
                }
            }
            //catch (SqlException ex)
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //mSqlDataReader.Close();
                //mSqlConnection.Close();

                dataReader.Close();
                mConnection.Close();
            }

            return allergyList;
        }

        public List<DeletedValue> GetAllDeletedValues()
        {
            string query = "SELECT * FROM deletedvalues";
            //SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

            OleDbCommand command = new OleDbCommand(query, mConnection);

            //SqlDataReader mSqlDataReader = null;
            OleDbDataReader dataReader = null; 

            List<DeletedValue> deletedValueList = new List<DeletedValue>();
            try
            {
                //mSqlConnection.Open();
                //mSqlDataReader = mSqlCommand.ExecuteReader();

                mConnection.Open();
                dataReader = command.ExecuteReader();

                // Check is the reader has any rows at all before starting to read.
                //if (mSqlDataReader.HasRows)
                if(dataReader.HasRows)
                {
                    // Read advances to the next row.
                    //while (mSqlDataReader.Read())
                    while(dataReader.Read())
                    {
                        //int recipeIngredientId = mSqlDataReader.GetInt32(mSqlDataReader.GetOrdinal("recipeIngredientId"));
                        //int iIsRecipe = mSqlDataReader.GetInt32(mSqlDataReader.GetOrdinal("isRecipe"));

                        int objectId = dataReader.GetInt32(dataReader.GetOrdinal("objectId"));
                        ObjectType objectType = (ObjectType) dataReader.GetInt32(dataReader.GetOrdinal("objectType"));
                        
                        DeletedValue deletedValue = new DeletedValue(objectId, objectType);

                        deletedValueList.Add(deletedValue);
                    }
                }
            }
            //catch (SqlException ex)
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error:" + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //mSqlDataReader.Close();
                //mSqlConnection.Close();

                dataReader.Close();
                mConnection.Close();
            }

            return deletedValueList;
        }
    }
}
