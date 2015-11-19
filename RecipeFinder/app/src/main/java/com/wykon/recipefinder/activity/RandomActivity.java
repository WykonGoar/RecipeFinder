package com.wykon.recipefinder.activity;

import android.content.Intent;
import android.content.res.TypedArray;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteException;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.wykon.recipefinder.R;
import com.wykon.recipefinder.model.DatabaseConnection;

import java.util.Random;

/**
 * Created by Wouter on 14-9-2015.
 */
public class RandomActivity extends DefaultActivity  {

    private String[] navigationMenuTitles;
    private TypedArray navigationMenuIcons;

    private DatabaseConnection mDatabaseConnection;

    private Spinner cbbBook;
    private Spinner cbbKitchen;
    private Spinner cbbCourse;
    private EditText etMinPersons;
    private EditText etMaxPersons;
    private EditText etMinTime;
    private EditText etMaxTime;
    private Spinner cbbLactoseFree;
    private Spinner cbbGlutenFree;
    private Spinner cbbFavorite;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_random);

        navigationMenuTitles = getResources().getStringArray(R.array.navigation_titles);
        navigationMenuIcons = getResources().obtainTypedArray(R.array.navigation_icons);
        set(navigationMenuTitles, navigationMenuIcons);

        SQLiteDatabase mDatabase = openOrCreateDatabase("RecipeFinderDB", MODE_PRIVATE, null);
        mDatabaseConnection = new DatabaseConnection(mDatabase, this);

        initializeLayout();
        fillSpinners();
    }

    private void initializeLayout(){
        cbbBook = (Spinner) findViewById(R.id.cbbBook);
        cbbKitchen = (Spinner) findViewById(R.id.cbbKitchen);
        cbbCourse = (Spinner) findViewById(R.id.cbbCourse);
        etMinPersons = (EditText) findViewById(R.id.etMinPersons);
        etMaxPersons = (EditText) findViewById(R.id.etMaxPersons);
        etMinTime = (EditText) findViewById(R.id.etMinTime);
        etMaxTime = (EditText) findViewById(R.id.etMaxTime);
        cbbLactoseFree = (Spinner) findViewById(R.id.cbbLactoseFree);
        cbbGlutenFree = (Spinner) findViewById(R.id.cbbGlutenFree);
        cbbFavorite = (Spinner) findViewById(R.id.cbbFavorite);

        Button bSearch = (Button) findViewById(R.id.bSearch);
        bSearch.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                activateSearch();
            }
        });
    }

    private void fillSpinners()
    {
        String bookValues[] = mDatabaseConnection.getColumnSearchValues("book");
        ArrayAdapter<String> bookArrayAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, bookValues); //selected item will look like a spinner set from XML
        bookArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        cbbBook.setAdapter(bookArrayAdapter);

        String kitchenValues[] = mDatabaseConnection.getColumnSearchValues("kitchen");
        ArrayAdapter<String> kitchenArrayAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, kitchenValues); //selected item will look like a spinner set from XML
        kitchenArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        cbbKitchen.setAdapter(kitchenArrayAdapter);

        String courseValues[] = mDatabaseConnection.getColumnSearchValues("course");
        ArrayAdapter<String> courseArrayAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, courseValues); //selected item will look like a spinner set from XML
        courseArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        cbbCourse.setAdapter(courseArrayAdapter);

        String allYesNoValues[] = getResources().getStringArray(R.array.cbbAllYesNo);
        ArrayAdapter<String> allYesNoArrayAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, allYesNoValues); //selected item will look like a spinner set from XML
        allYesNoArrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        cbbFavorite.setAdapter(allYesNoArrayAdapter);
        cbbLactoseFree.setAdapter(allYesNoArrayAdapter);
        cbbGlutenFree.setAdapter(allYesNoArrayAdapter);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_search, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.


        return super.onOptionsItemSelected(item);
    }

    private void activateSearch(){
        String query = "SELECT _id FROM recipes WHERE hide = 0";

        String whereStatement = "";
        String allValue = getResources().getString(R.string.cbbAllValue);

        String book = cbbBook.getSelectedItem().toString();
        if (!book.equals(allValue))
            whereStatement += " AND book = '" + book + "'";

        String kitchen = cbbKitchen.getSelectedItem().toString();
        if(!kitchen.equals(allValue))
            whereStatement += " AND kitchen = '"+ kitchen + "'";

        String course = cbbCourse.getSelectedItem().toString();
        if(!course.equals(allValue))
            whereStatement += " AND course = '"+ course + "'";

        String yesNoAwnser[] = getResources().getStringArray(R.array.cbbAllYesNo);

        String favorite = cbbFavorite.getSelectedItem().toString();
        String all = yesNoAwnser[0];
        if(!favorite.equals(yesNoAwnser[0])) {
            whereStatement += " AND favorite =";
            if (favorite.equals(yesNoAwnser[1]))
                whereStatement += 1;
            else
                whereStatement += 0;
        }

        String lactoseFree = cbbLactoseFree.getSelectedItem().toString();
        if(!lactoseFree.equals(yesNoAwnser[0])) {
            whereStatement += " AND lactosefree =";
            if (lactoseFree.equals(yesNoAwnser[1]))
                whereStatement += 1;
            else
                whereStatement += 0;
        }

        String glutenFree = cbbGlutenFree.getSelectedItem().toString();
        if(!glutenFree.equals(yesNoAwnser[0])) {
            whereStatement += " AND glutenfree =";
            if (glutenFree.equals(yesNoAwnser[1]))
                whereStatement += 1;
            else
                whereStatement += 0;
        }

        String sMinPersons = etMinPersons.getText().toString();
        String sMaxPersons = etMaxPersons.getText().toString();
        if(!sMinPersons.isEmpty() && !sMaxPersons.isEmpty())
        {
            int minPersons = Integer.parseInt(sMinPersons);
            int maxPersons = Integer.parseInt(sMaxPersons);

            if(minPersons < maxPersons)
                whereStatement += " AND persons BETWEEN " + minPersons + " AND " + maxPersons;
            else if (minPersons == maxPersons)
                whereStatement +=  " AND persons = " + minPersons;
            else {
                Toast.makeText(this, "Personen is fout ingevuld. Mogelijke antwoorden zijn 1-4 of 4-4",Toast.LENGTH_LONG).show();
                return;
            }
        }

        String sMinTime = etMinTime.getText().toString();
        String sMaxTime = etMaxTime.getText().toString();
        if(!sMinTime.isEmpty() && !sMaxTime.isEmpty())
        {
            int minTime = Integer.parseInt(sMinTime);
            int maxTime = Integer.parseInt(sMaxTime);

            if(minTime < maxTime)
                whereStatement += " AND maxPreperationTime BETWEEN " + minTime + " AND " + maxTime;
            else if (minTime == maxTime)
                whereStatement +=  " AND maxPreperationTime = " + minTime;
            else {
                Toast.makeText(this, "Bereidings tijd is fout ingevuld. Mogelijke antwoorden zijn 5-10 of 10-10",Toast.LENGTH_LONG).show();
                return;
            }
        }

        query += whereStatement;

        Cursor mCursor = null;
        try {
            mCursor = mDatabaseConnection.executeReturn(query);
        } catch (SQLiteException e) {
            e.printStackTrace();
        }

        mCursor.moveToFirst();

        int rowCount = mCursor.getCount();
        if(rowCount == 0){
            Toast.makeText(this, "Geen recepten gevonden.", Toast.LENGTH_LONG).show();
            return;
        }

        Random random = new Random();
        int randomNumber = random.nextInt(rowCount - 1);

        mCursor.moveToPosition(randomNumber);
        int recipeId = mCursor.getInt(0);

        Intent mIntent = new Intent(getApplicationContext(), RecipeActivity.class);
        mIntent.putExtra("id", recipeId);

        startActivity(mIntent);
    }
}
