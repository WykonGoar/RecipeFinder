package com.wykon.recipefinder.activity;

import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.content.res.TypedArray;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.TextView;

import com.wykon.recipefinder.R;
import com.wykon.recipefinder.model.DatabaseConnection;
import com.wykon.recipefinder.model.Recipe;
import com.wykon.recipefinder.model.RecipeListAdapter;

public class FavoriteListActivity extends DefaultActivity {

    private String[] navigationMenuTitles;
    private TypedArray navigationMenuIcons;

    private Recipe[] recipes = new Recipe[0];

    private DatabaseConnection mDatabaseConnection;

    private ListView recipeList;
    private MenuItem mSearchAction;
    private boolean isSearchOpen = false;
    private EditText mSearchText;

    private String mOrderBy = "title";
    private boolean mDecrease = false;
    private String mWhereValue = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_favorite_list);

        SQLiteDatabase mDatabase = openOrCreateDatabase("RecipeFinderDB", MODE_PRIVATE, null);
        mDatabaseConnection = new DatabaseConnection(mDatabase, this);

        navigationMenuTitles = getResources().getStringArray(R.array.navigation_titles);
        navigationMenuIcons = getResources().obtainTypedArray(R.array.navigation_icons);
        set(navigationMenuTitles, navigationMenuIcons);

        recipeList = (ListView) findViewById(R.id.lvRecipes);

        recipeList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position,
                                    long id) {
                recipeClicked(position);
            }
        });
    }

    private void loadRecipes(String whereValue, String orderBy, boolean decrease)
    {
        if(whereValue != null)
            mWhereValue = whereValue;

        if(orderBy != null)
            mOrderBy = orderBy;
        mDecrease = decrease;

        String queryWhere = "hide = 0 AND favorite = 1";
        if(mWhereValue != null)
            queryWhere += " " + mWhereValue;

        String queryOrder = "";
        if(mOrderBy != null)
            queryOrder = "ORDER BY " + mOrderBy;

        if(mDecrease)
            queryOrder += " DESC";

        String query = "SELECT * FROM recipes WHERE " + queryWhere + " " + queryOrder;
        recipes = mDatabaseConnection.loadRecipes(query);

        RecipeListAdapter mRecipeListAdapter = new RecipeListAdapter(this, recipes);
        recipeList.setAdapter(mRecipeListAdapter);
    }

    @Override
    protected void onStart(){
        super.onStart();

        loadRecipes(null, null, false);
    }

    private void recipeClicked(int position){
        Recipe mRecipe = recipes[position];

        Intent mIntent = new Intent(getApplicationContext(), RecipeActivity.class);
        mIntent.putExtra("id", mRecipe.getId());

        startActivity(mIntent);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_list, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        switch (id) {
            //noinspection SimplifiableIfStatement
            case R.id.action_search:
                handleMenuSearch();
                break;
            case R.id.order_by:
                handleMenuOrderBy();
                break;
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {
        mSearchAction = menu.findItem(R.id.action_search);
        return super.onPrepareOptionsMenu(menu);
    }

    private void handleMenuSearch() {
        ActionBar actionBar = getSupportActionBar();

        if (isSearchOpen) {
            actionBar.setDisplayShowCustomEnabled(false);
            actionBar.setDisplayShowTitleEnabled(true);

            InputMethodManager inputMethodManager = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
            inputMethodManager.hideSoftInputFromWindow(mSearchText.getWindowToken(), 0);

            mSearchAction.setIcon(getResources().getDrawable(R.drawable.search_icon_small));

            loadRecipes("", null, false);

            isSearchOpen = false;
        } else {
            actionBar.setDisplayShowCustomEnabled(true);
            actionBar.setCustomView(R.layout.search_bar);
            actionBar.setDisplayShowTitleEnabled(false);

            mSearchText = (EditText) actionBar.getCustomView().findViewById(R.id.etSearch);
            mSearchText.setOnEditorActionListener(new TextView.OnEditorActionListener() {

                @Override
                public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                    if (actionId == EditorInfo.IME_ACTION_SEARCH) {
                        loadRecipes("AND title LIKE '%" + mSearchText.getText() +"%'", "title", false);
                        return true;
                    }
                    return false;
                }
            });

            mSearchText.requestFocus();
            InputMethodManager inputMethodManager = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
            inputMethodManager.showSoftInput(mSearchText, InputMethodManager.SHOW_IMPLICIT);

            mSearchAction.setIcon(getResources().getDrawable(R.drawable.cancel_icon));

            isSearchOpen = true;
        }
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

                loadRecipes(null, mOrderBy, mDecrease);
                dialog.dismiss();
            }
        });

        dialog.show();
    }

    @Override
    public void onBackPressed() {
        if(isSearchOpen){
            handleMenuSearch();
            return;
        }
        super.onBackPressed();
    }
}
