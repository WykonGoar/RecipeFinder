using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderDatabase.Models
{
    public class DeletedValue
    {
        private int mObjectId;
        private ObjectType mObjectType;

        public DeletedValue(int objectId, ObjectType objectType) 
        {
            mObjectId = objectId;
            mObjectType = objectType;
        }

        public string GetDeleteQuery()
        {
            string query = null;
            switch(mObjectType)
            {
                case ObjectType.Recipe:
                    query = "DELETE FROM recipes WHERE id = " + mObjectId + ";";
                    break;

                case ObjectType.Ingredient:
                    query = "DELETE FROM ingredients WHERE id = " + mObjectId + ";";
                    break;

                case ObjectType.Allergy:
                    query = "DELETE FROM allergies WHERE id = " + mObjectId + ";";
                    break;

                case ObjectType.RecipeAllergy:
                    query = "DELETE FROM allergiesrecipes WHERE id = " + mObjectId + ";";
                    break;
            }

            return query;
        }
    }

    public enum ObjectType
    {
        Recipe,
        Ingredient,
        Allergy,
        RecipeAllergy
    }
}
