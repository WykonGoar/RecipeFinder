package com.wykon.recipefinder.model;

import android.app.Activity;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteException;

import com.wykon.recipefinder.R;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.logging.Logger;

/**
 * Created by Wouter on 7-9-2015.
 */
public class DatabaseConnection extends Activity{

    SQLiteDatabase mDatabase;
    Context mContext;
    Logger log;

    public DatabaseConnection(SQLiteDatabase database, Context context){
        mDatabase = database;
        mContext = context;

        try{
            String check = "SELECT * FROM recipes";


            executeReturn(check);
        } catch (SQLiteException ex)
        {
            importDatabaseTables();
            //importRecipes();
        }

    }

    private void importDatabaseTables(){
        try {
            InputStream mInputStream = mContext.getAssets().open("RecipeFinderTables.sql");

            BufferedReader mBufferedReader = new BufferedReader(new InputStreamReader(mInputStream));

            String line = null;
            do {
                line = mBufferedReader.readLine();
                if (line != null) {
                    executeNonReturn(line);
                }
            } while (line != null);
        }catch (IOException ex){
            throw new Error(ex.getMessage());
        }
    }

    private void importRecipes(){
        try {
            InputStream mInputStream = mContext.getAssets().open("NewRecipes.sql");

            BufferedReader mBufferedReader = new BufferedReader(new InputStreamReader(mInputStream));

            String line = null;
            do {
                line = mBufferedReader.readLine();
                if (line != null) {
                    try {
                        executeNonReturn(line);
                    }
                    catch (SQLiteException ex) {
                        throw new Error(ex.getMessage());
                    }
                }
            } while (line != null);
        }catch (IOException ex){
            throw new Error(ex.getMessage());
        }
    }

    public void executeNonReturn(String query) throws  SQLiteException{
        mDatabase.execSQL(query);
    }

    public Cursor executeReturn(String query) throws SQLiteException{
      return mDatabase.rawQuery(query, null);
    }

    public Recipe[] loadRecipes(String query){
        Cursor mCursor = null;
        try {
            mCursor = executeReturn(query);
        } catch (SQLiteException e) {
            e.printStackTrace();
        }

        mCursor.moveToFirst();

        int rowCount = mCursor.getCount();
        Recipe mRecipes[] = new Recipe[rowCount];
        int recipeCount = 0;

        while(!mCursor.isAfterLast()){
            //Id
            int id = mCursor.getInt(mCursor.getColumnIndex("_id"));
            //book
            String book = mCursor.getString(mCursor.getColumnIndex("book"));
            //page
            int page = mCursor.getInt(mCursor.getColumnIndex("page"));
            //kitchen
            String kitchen = mCursor.getString(mCursor.getColumnIndex("kitchen"));
            //course
            String course = mCursor.getString(mCursor.getColumnIndex("course"));
            //title
            String title = mCursor.getString(mCursor.getColumnIndex("title"));
            //max preperation time
            int maxPreperationTime = mCursor.getInt(mCursor.getColumnIndex("maxPreperationTime"));
            // persons
            int persons = mCursor.getInt(mCursor.getColumnIndex("persons"));
            //favorite
            int iFavorite = mCursor.getInt(mCursor.getColumnIndex("favorite"));
            Boolean favorite = false;
            if(iFavorite == 1)
                favorite = true;
            //lactose free
            int iLactoseFree = mCursor.getInt(mCursor.getColumnIndex("lactosefree"));
            Boolean lactoseFree = false;
            if(iLactoseFree == 1)
                lactoseFree = true;
            //gluten free
            int iGlutenFree = mCursor.getInt(mCursor.getColumnIndex("glutenfree"));
            Boolean glutenFree = false;
            if(iGlutenFree == 1)
                glutenFree = true;
            //hide
            int iHide = mCursor.getInt(mCursor.getColumnIndex("hide"));
            Boolean hide = false;
            if(iHide == 1)
                hide = true;

            Recipe mRecipe = new Recipe(id, book, page, kitchen, course, title, maxPreperationTime, persons, favorite, lactoseFree, glutenFree, hide);
            mRecipes[recipeCount] = mRecipe;
            recipeCount ++;
            mCursor.moveToNext();
        }

        return  mRecipes;
    }

    public Ingredient[] getIngredients(int recipeId)
    {
        String query = "SELECT * FROM ingredients WHERE recipeid = " + recipeId + " ORDER BY name";
        Cursor mCursor = null;
        try {
            mCursor = executeReturn(query);
        } catch (SQLiteException e) {
            e.printStackTrace();
        }
        mCursor.moveToFirst();

        int rowCount = mCursor.getCount();
        Ingredient mIngredients[] = new Ingredient[rowCount];
        int ingredientCount = 0;

        while(!mCursor.isAfterLast()){
            //id
            int id = mCursor.getInt(mCursor.getColumnIndex("_id"));
            //recipeID
            int cRecipeId = mCursor.getInt(mCursor.getColumnIndex("recipeId"));
            //name
            String name = mCursor.getString(mCursor.getColumnIndex("name"));
            //amount
            double amount = mCursor.getDouble(mCursor.getColumnIndex("amount"));
            //measure
            String measure = mCursor.getString(mCursor.getColumnIndex("measure"));

            Ingredient ingredient = new Ingredient(id, recipeId, name, amount, measure);
            mIngredients[ingredientCount] = ingredient;
            ingredientCount++;

            mCursor.moveToNext();
        }

        return  mIngredients;
    }

    public String[] getColumnSearchValues(String columnName){
        Cursor mCursor = null;
        String columnValues[] = null;
        try {
            mCursor = executeReturn("SELECT DISTINCT(" + columnName + ") FROM recipes WHERE hide=0 ORDER BY " + columnName);

            mCursor.moveToFirst();

            int rowCount = mCursor.getCount();
            columnValues = new String[rowCount + 1];
            int valueCount = 1;

            columnValues[0] = (String) mContext.getResources().getText(R.string.cbbAllValue);
            while(!mCursor.isAfterLast()) {
                String columnValue = mCursor.getString(0);
                columnValues[valueCount] = columnValue;

                valueCount++;
                mCursor.moveToNext();
            }
        } catch (SQLiteException e) {
            e.printStackTrace();
        }
        return columnValues;
    }
}
