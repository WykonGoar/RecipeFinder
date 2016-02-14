using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace RecipeFinderDatabase.Models
{
    public class Allergy
    {
        private int mId;
        private string mName;

        public Allergy() { }

        public int Id { get { return mId; } set { mId = value; } }
        public string Name { get { return mName; } set { mName = value; } }

        public OleDbCommand GetInsertQuery()
        {
            string query = "INSERT INTO allergies (name) VALUES (@P0);";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@P0", mName);

            return command;
        }

        public OleDbCommand[] GetDeleteQuerys()
        {
            OleDbCommand[] commands = new OleDbCommand[2];

            string deletedValuesCommandQuery = "INSERT INTO DeletedValues (objectId, objectType) VALUES (@P0, @P1);";
            OleDbCommand deletedValuesCommand = new OleDbCommand(deletedValuesCommandQuery);
            deletedValuesCommand.Parameters.AddWithValue("@P0", mId);
            deletedValuesCommand.Parameters.AddWithValue("@P1", ObjectType.Allergy);
            commands[0] = deletedValuesCommand;

            string deleteQuery = "DELETE FROM allergies WHERE id = @P0";
            OleDbCommand deleteCommand = new OleDbCommand(deleteQuery);
            deleteCommand.Parameters.AddWithValue("@P0", mId);
            commands[1] = deleteCommand;

            return commands;
        }

        public String GetExportString()
        {
            string query = "INSERT INTO allergies (id, name) VALUES (@id, @name);";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@id", mId);
            command.Parameters.AddWithValue("@name", mName);

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
