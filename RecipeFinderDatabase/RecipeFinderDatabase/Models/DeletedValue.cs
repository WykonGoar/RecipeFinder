using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderDatabase.Models
{
    public class DeletedValue
    {
        private int mRecipeIngredientId;
        private bool mIsRecipe;

        public DeletedValue(int recipeIngredientId, bool isRecipe) 
        {
            mRecipeIngredientId = recipeIngredientId;
            mIsRecipe = isRecipe;
        }

        public string GetDeleteQuery()
        {
            if (mIsRecipe)
                return "DELETE FROM recipes WHERE id = " + mRecipeIngredientId + ";";
            else
                return "DELETE FROM ingredients WHERE id = " + mRecipeIngredientId + ";";
        }
    }
}
