package com.wykon.recipefinder.activity;

import android.app.Dialog;
import android.content.Intent;
import android.content.res.TypedArray;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.RadioButton;

import com.wykon.recipefinder.R;
import com.wykon.recipefinder.model.DatabaseConnection;
import com.wykon.recipefinder.model.Recipe;
import com.wykon.recipefinder.model.RecipeListAdapter;

/**
 * Created by Wouter on 14-9-2015.
 */
public class ResultListActivity  extends DefaultActivity {

    private String[] navigationMenuTitles;
    private TypedArray navigationMenuIcons;

    private DatabaseConnection mDatabaseConnection;

    private Recipe[] recipes = new Recipe[0];
    private String mainQuery;

    private ListView recipeList;

    private String mOrderBy = "title";
    private boolean mDecrease = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_result_list);

        navigationMenuTitles = getResources().getStringArray(R.array.navigation_titles);
        navigationMenuIcons = getResources().obtainTypedArray(R.array.navigation_icons);
        set(navigationMenuTitles, navigationMenuIcons);

        SQLiteDatabase mDatabase = openOrCreateDatabase("RecipeFinderDB", MODE_PRIVATE, null);
        mDatabaseConnection = new DatabaseConnection(mDatabase, this);

        recipeList = (ListView) findViewById(R.id.lvRecipes);

        Intent mIntent = getIntent();
        mainQuery = mIntent.getStringExtra("query");

        recipeList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position,
                                    long id) {
                recipeClicked(position);
            }
        });
    }

    private void loadRecipes(String orderBy, boolean decrease) {
        if (orderBy != null)
            mOrderBy = orderBy;
        mDecrease = decrease;

        String queryOrder = "";
        if (mOrderBy != null)
            queryOrder = " ORDER BY " + mOrderBy;

        if (mDecrease)
            queryOrder += " DESC";

        String query = mainQuery + queryOrder;
        recipes = mDatabaseConnection.loadRecipes(query);

        RecipeListAdapter mRecipeListAdapter = new RecipeListAdapter(this, recipes);
        recipeList.setAdapter(mRecipeListAdapter);
    }

    @Override
    protected void onStart() {
        super.onStart();

        loadRecipes(null, false);
    }

    private void recipeClicked(int position) {
        Recipe mRecipe = recipes[position];

        Intent mIntent = new Intent(getApplicationContext(), RecipeActivity.class);
        mIntent.putExtra("id", mRecipe.getId());

        startActivity(mIntent);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_result_list, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        switch (id) {
            //noinspection SimplifiableIfStatement
            case R.id.order_by:
                handleMenuOrderBy();
                break;
        }

        return super.onOptionsItemSelected(item);
    }

    private void handleMenuOrderBy() {
        final Dialog dialog = new Dialog(this);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        dialog.setContentView(R.layout.oderby_dialog);
        final RadioButton rbTitle = (RadioButton) dialog.findViewById(R.id.radioTitle);
        final RadioButton rbKitchen = (RadioButton) dialog.findViewById(R.id.radioKitchen);
        final RadioButton rbCourse = (RadioButton) dialog.findViewById(R.id.radioCourse);
        final RadioButton rbTime = (RadioButton) dialog.findViewById(R.id.radioMaxPreperationTime);
        RadioButton rbIncrease = (RadioButton) dialog.findViewById(R.id.radioIncrease);
        final RadioButton rbDecrease = (RadioButton) dialog.findViewById(R.id.radioDecrease);

        Button bCancel = (Button) dialog.findViewById(R.id.bCancel);
        Button bOrder = (Button) dialog.findViewById(R.id.bOrder);

        switch (mOrderBy) {
            case "title":
                rbTitle.setChecked(true);
                break;
            case "kitchen":
                rbKitchen.setChecked(true);
                break;
            case "course":
                rbCourse.setChecked(true);
                break;
            case "maxPreperationTime":
                rbTime.setChecked(true);
                break;
        }

        if (mDecrease)
            rbDecrease.setChecked(true);
        else
            rbIncrease.setChecked(true);

        bCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dialog.cancel();
            }
        });

        bOrder.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String mOrderBy = "";
                boolean mDecrease = false;

                if (rbTitle.isChecked())
                    mOrderBy = "title";
                if (rbKitchen.isChecked())
                    mOrderBy = "kitchen";
                if (rbCourse.isChecked())
                    mOrderBy = "course";
                if (rbTime.isChecked())
                    mOrderBy = "maxPreperationTime";
                if (rbDecrease.isChecked())
                    mDecrease = true;

                loadRecipes(mOrderBy, mDecrease);
                dialog.dismiss();
            }
        });

        dialog.show();
    }
}


