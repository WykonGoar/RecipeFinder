using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace RecipeFinderDatabase.Models
{
    public class Ingredient
    {
        private int mId;
        private int mRecipeId;
        private string mName;
        private string mAmount;
        private string mMeasure;

        public Ingredient() { }

        public int Id { get { return mId; } set { mId = value; } }
        public int RecipeId { get { return mRecipeId; } set { mRecipeId = value; } }
        public string Name { get { return mName; } set { mName = value; } }
        public string Amount { get { return mAmount; } set { mAmount = value; } }
        public string Measure { get { return mMeasure; } set { mMeasure = value; } }

        public OleDbCommand GetUpdateQuery()
        {
            string query = "UPDATE ingredients SET recipeId = @P0, name = @P1, amount = @P2, measure = @P3 WHERE id = @P4;";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@P0", mRecipeId);
            command.Parameters.AddWithValue("@P1", mName);
            command.Parameters.AddWithValue("@P2", mAmount);
            command.Parameters.AddWithValue("@P3", mMeasure);
            command.Parameters.AddWithValue("@P4", mId);

            return command;
        }

        public OleDbCommand GetInsertQuery()
        {
            string query = "INSERT INTO ingredients (recipeId, name, amount, measure) VALUES (@P0, @P1, @P2, @P3);";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@P0", mRecipeId);
            command.Parameters.AddWithValue("@P1", mName);
            command.Parameters.AddWithValue("@P2", mAmount);
            command.Parameters.AddWithValue("@P3", mMeasure);

            return command;
        }

        public OleDbCommand[] GetDeleteQuerys()
        {
            OleDbCommand[] commands = new OleDbCommand[2];

            string deletedValuesCommandQuery = "INSERT INTO DeletedValues (recipeIngredientId, isRecipe) VALUES (@P0, 0);";
            OleDbCommand deletedValuesCommand = new OleDbCommand(deletedValuesCommandQuery);
            deletedValuesCommand.Parameters.AddWithValue("@P0", mId);
            commands[0] = deletedValuesCommand;

            string deleteQuery = "DELETE FROM ingredients WHERE id = @P0;";
            OleDbCommand deleteCommand = new OleDbCommand(deleteQuery);
            deleteCommand.Parameters.AddWithValue("@P0", mId);
            commands[1] = deleteCommand;

            return commands;
        }

        public String GetExportString()
        {
            string query = "INSERT INTO ingredients (id, recipeId, name, amount, measure) VALUES (@P0, @P1, @P2, @P3, @P4);";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@P0", mId);
            command.Parameters.AddWithValue("@P1", mRecipeId);
            command.Parameters.AddWithValue("@P2", mName);
            command.Parameters.AddWithValue("@P3", mAmount);
            command.Parameters.AddWithValue("@P4", mMeasure);

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
