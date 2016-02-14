using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace RecipeFinderDatabase.Models
{
    public class Recipe
    {
        private int mId;
        private string mBook;
        private int mPage;
        private string mKitchen;
        private string mCourse;
        private string mTitle;
        private int mMaxPreperationTime;
        private int mPersons;
        private bool mFavorite;
        private bool mHide;
        private List<Ingredient> mIngredients;
        private List<AllergiesRecipes> mAllergies;

        public Recipe()
        { }

        public int Id { get { return mId; } set { mId = value; } }
        public string Book { get { return mBook; } set { mBook = value; } }
        public int Page { get { return mPage; }  set {mPage = value;} }
        public string Kitchen { get { return mKitchen; } set { mKitchen = value; } }
        public string Course { get { return mCourse; } set { mCourse = value; } }
        public string Title { get { return mTitle; } set { mTitle = value; } }
        public int MaxPreperationTime { get { return mMaxPreperationTime; } set { mMaxPreperationTime = value; } }
        public int Persons { get { return mPersons; } set { mPersons = value; } }
        public bool Favorite { get { return mFavorite; } set { mFavorite = value; } }
        public int FavoriteInt 
        {
            get
            {
                int favorite = 0;
                if (mFavorite)
                    favorite = 1;

                return favorite;
            }
            set
            {
                if (value == 1)
                    mFavorite = true;
                else
                    mFavorite = false;
            }
        }
        public bool Hide { get { return mHide; } set { mHide = value; } }
        public int HideInt
        {
            get
            {
                int hide = 0;
                if (mHide)
                    hide = 1;

                return hide;
            }
            set
            {
                if (value == 1)
                    mHide = true;
                else
                    mHide = false;
            }
        }
        public List<Ingredient> Ingredients { get { return mIngredients; } set { mIngredients = value; } }

        public List<AllergiesRecipes> Allergies { get { return mAllergies; } set { mAllergies = value; } }

        public OleDbCommand GetUpdateQuery()
        {
            string query = "UPDATE recipes SET book = @book, page = @page, kitchen = @kitchen, course = @course, title = @title, maxPreperationTime = @time, persons = @persons, favorite = @favorite, hide = @hide WHERE id = @id;";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@book", mBook);
            command.Parameters.AddWithValue("@page", mPage);
            command.Parameters.AddWithValue("@kitchen", mKitchen);
            command.Parameters.AddWithValue("@course", mCourse);
            command.Parameters.AddWithValue("@title", mTitle);
            command.Parameters.AddWithValue("@time", mMaxPreperationTime);
            command.Parameters.AddWithValue("@persons", mPersons);
            command.Parameters.AddWithValue("@favorite", FavoriteInt);
            command.Parameters.AddWithValue("@hide", HideInt);
            command.Parameters.AddWithValue("@id", mId);

            return command;
        }

        public OleDbCommand GetInsertQuery()
        {
            string query = "INSERT INTO recipes (book,page,kitchen,course,title,maxPreperationTime,persons,favorite,hide) VALUES (@P0, @P1, @P2, @P3, @P4, @P5, @P6, @P7, @P8);";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@P0", mBook);
            command.Parameters.AddWithValue("@P1", mPage);
            command.Parameters.AddWithValue("@P2", mKitchen);
            command.Parameters.AddWithValue("@P3", mCourse);
            command.Parameters.AddWithValue("@P4", mTitle);
            command.Parameters.AddWithValue("@P5", mMaxPreperationTime);
            command.Parameters.AddWithValue("@P6", mPersons);
            command.Parameters.AddWithValue("@P7", FavoriteInt);
            command.Parameters.AddWithValue("@P8", HideInt);

            return command;
        }

        public OleDbCommand[] GetDeleteQuerys()
        {
            OleDbCommand[] commands = new OleDbCommand[2];

            string deletedValuesCommandQuery = "INSERT INTO DeletedValues (objectId, objectType) VALUES (@P0, @P1);";
            OleDbCommand deletedValuesCommand = new OleDbCommand(deletedValuesCommandQuery);
            deletedValuesCommand.Parameters.AddWithValue("@P0", mId);
            deletedValuesCommand.Parameters.AddWithValue("@P1", ObjectType.Recipe);
            commands[0] = deletedValuesCommand;

            string deleteQuery = "DELETE FROM recipes WHERE id = @P0";
            OleDbCommand deleteCommand = new OleDbCommand(deleteQuery);
            deleteCommand.Parameters.AddWithValue("@P0", mId);
            commands[1] = deleteCommand;

            return commands;
        }
    
        public String GetExportString()
        {
            string query = "INSERT INTO recipes (id, book,page,kitchen,course,title,maxPreperationTime,persons,favorite,hide) VALUES (@id, @book, @page, @kitchen, @course, @title, @time, @persons, @favorite, @hide);";
            OleDbCommand command = new OleDbCommand(query);
            command.Parameters.AddWithValue("@id", mId);
            command.Parameters.AddWithValue("@book", mBook);
            command.Parameters.AddWithValue("@page", mPage);
            command.Parameters.AddWithValue("@kitchen", mKitchen);
            command.Parameters.AddWithValue("@course", mCourse);
            command.Parameters.AddWithValue("@title", mTitle);
            command.Parameters.AddWithValue("@time", mMaxPreperationTime);
            command.Parameters.AddWithValue("@persons", mPersons);
            command.Parameters.AddWithValue("@favorite", FavoriteInt);
            command.Parameters.AddWithValue("@hide", HideInt);

            foreach(OleDbParameter parameter in command.Parameters)
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
