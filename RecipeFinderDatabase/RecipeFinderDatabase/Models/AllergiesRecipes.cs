using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace RecipeFinderDatabase.Models
{
    public class AllergiesRecipes
    {
        private int mId;
        private int mRecipeId;
        private int mAllergyId;
        private string mName;

        public AllergiesRecipes() { }

        public int Id { get { return mId; } set { mId = value; } }
        public int RecipeId { get { return mRecipeId; } set { mRecipeId = value; } }
        public int AllergyId { get { return mAllergyId; } set { mAllergyId = value; } }
        public string Name { get { return mName; } set { mName = value; } }

        public OleDbCommand GetInsertQuery()
        {
            string query = "INSERT INTO allergiesrecipes (recipeId, allergyId) VALUES (@P0, @P1);";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@P0", mRecipeId);
            command.Parameters.AddWithValue("@P1", mAllergyId);

            return command;
        }

        public OleDbCommand[] GetDeleteQuerys()
        {
            OleDbCommand[] commands = new OleDbCommand[2];

            string deletedValuesCommandQuery = "INSERT INTO DeletedValues (objectId, objectType) VALUES (@P0, @P1);";
            OleDbCommand deletedValuesCommand = new OleDbCommand(deletedValuesCommandQuery);
            deletedValuesCommand.Parameters.AddWithValue("@P0", mId);
            deletedValuesCommand.Parameters.AddWithValue("@P1", ObjectType.RecipeAllergy);
            commands[0] = deletedValuesCommand;

            string deleteQuery = "DELETE FROM allergiesrecipes WHERE id = @P0";
            OleDbCommand deleteCommand = new OleDbCommand(deleteQuery);
            deleteCommand.Parameters.AddWithValue("@P0", mId);
            commands[1] = deleteCommand;

            return commands;
        }

        public String GetExportString()
        {
            string query = "INSERT INTO allergiesrecipes (recipeId, allergyId) VALUES (@recipe, @allergy);";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@recipe", mRecipeId);
            command.Parameters.AddWithValue("@allergy", mAllergyId);

            foreach (OleDbParameter parameter in command.Parameters)
            {
                string replaceValue = parameter.Value.ToString();
                if (parameter.OleDbType == OleDbType.VarChar)
                    replaceValue = @"'" + replaceValue + "'";

                query = query.Replace(parameter.ParameterName, replaceValue);
            }

            return query;
        }
    }
}
