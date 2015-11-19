package com.wykon.recipefinder.model;

import android.content.Context;
import android.database.sqlite.SQLiteException;
import android.os.Environment;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;

/**
 * Created by Wouter on 14-9-2015.
 */
public class IORecipes {

    private Context mContext;
    private DatabaseConnection mDatabaseConnection;

    public IORecipes(Context context, DatabaseConnection databaseConnection)
    {
        mContext = context;
        mDatabaseConnection = databaseConnection;
    }

    public boolean exportRecipes(){
        File directory = getDirectory();
        File exportFile = new File(directory, "ExportRecipes.txt");
        exportFile.deleteOnExit();
        Recipe recipes[] = mDatabaseConnection.loadRecipes("SELECT * FROM recipes");

        try {
            PrintStream mPrintStream = new PrintStream(exportFile);
            for(int r = 0; r <recipes.length; r++)
            {
                Recipe recipe = recipes[r];
                mPrintStream.println(recipe.getUpdateQuery());

                Ingredient[] ingredients = mDatabaseConnection.getIngredients(recipe.getId());
                for (int i = 0; i <recipes.length; i++)
                {
                    Ingredient ingredient = ingredients[i];
                    mPrintStream.println(ingredient.getUpdateQuery());
                }
            }

            mPrintStream.close();
        } catch (IOException e) {
            e.printStackTrace();
            return false;
        }

        return  true;
    }

    public boolean importRecipes()
    {
        try {
            File directory = getDirectory();
            File importFile = new File(directory, "ImportRecipes.txt");
            FileInputStream mFileInputStream = new FileInputStream(importFile);

            BufferedReader mBufferedReader = new BufferedReader(new InputStreamReader(mFileInputStream));

            String line = null;
            do {
                line = mBufferedReader.readLine();
                if (line != null) {
                    try {
                        mDatabaseConnection.executeNonReturn(line);
                    }
                    catch (SQLiteException ex)
                    {
                        String errorMessage = ex.getMessage();
                        String codeText = errorMessage.substring(errorMessage.lastIndexOf("(code") + 6, errorMessage.lastIndexOf(")"));
                        if(codeText.equals("1555"))
                        {
                            String updateQuery = "";

                            if(line.contains("INSERT INTO recipes"))
                            {
                                updateQuery = "UPDATE recipes SET ";
                                line = line.replace("INSERT INTO recipes (", "");
                                updateQuery += convertInsertToUpdate(line);
                            }
                            else if(line.contains("INSERT INTO ingredients"))
                            {
                                updateQuery = "UPDATE ingredients SET ";
                                line = line.replace("INSERT INTO ingredients (", "");
                                updateQuery += convertInsertToUpdate(line);
                            }

                            try{
                                mDatabaseConnection.executeNonReturn(updateQuery);
                            }
                            catch (SQLiteException ex2)
                            {
                                String errorMessage2 = ex2.getMessage();
                                //Do nothing
                            }
                        }
                    }
                }
            } while (line != null);
        }catch (IOException ex){
            return false;
        }

        return true;
    }

    private String convertInsertToUpdate(String currentQuery){
        String newQuery = "";
        String whereValue = "";

        String columnValues = currentQuery.substring(0, currentQuery.indexOf(")"));
        String insertValues = currentQuery.substring(currentQuery.indexOf("VALUES (") + 8, currentQuery.lastIndexOf(")"));

        String[] columns = columnValues.split(",");
        String[] values = insertValues.split(",");
        for(int i = 0; i < columns.length; i++)
        {
            String column = columns[i];
            String value = values[i];

            if(column.equals("_id")){
                whereValue = " WHERE _id = " + value;
            }
            else {
                newQuery += ", " + column + " = " + value;
            }
        }

        newQuery = newQuery.substring(1) + whereValue;
        return newQuery;
    }

    private File getDirectory(){
        File directory = new File(Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOCUMENTS), "/RecipeFinder");
        directory.mkdirs();

        return directory;
    }

    public boolean isExternalStorageWritable() {
        String state = Environment.getExternalStorageState();
        if (Environment.MEDIA_MOUNTED.equals(state)) {
            return true;
        }
        return false;
    }
}
