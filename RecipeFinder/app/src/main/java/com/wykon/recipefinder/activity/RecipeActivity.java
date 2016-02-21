package com.wykon.recipefinder.activity;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.res.TypedArray;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TableLayout;
import android.widget.TextView;

import com.wykon.recipefinder.R;
import com.wykon.recipefinder.model.DatabaseConnection;
import com.wykon.recipefinder.model.activitylists.AllergyListAdapter;
import com.wykon.recipefinder.model.objects.Allergy;
import com.wykon.recipefinder.model.objects.Ingredient;
import com.wykon.recipefinder.model.activitylists.IngredientListAdapter;
import com.wykon.recipefinder.model.objects.Recipe;

public class RecipeActivity extends DefaultActivity {
    enum RecipeViews{
        DETAILS,
        ALLERGIES,
        INGREDIENTS
    }

    private String[] navigationMenuTitles;
    private TypedArray navigationMenuIcons;
    Recipe mRecipe = null;

    private DatabaseConnection mDatabaseConnection;

    private Button bTabDetails;
    private Button bTabAllergies;
    private Button bTabIngredients;

    private TableLayout tlDetails;
    private ListView lvAllergies;
    private ListView lvIngredients;

    private TextView tvTitle;
    private TextView tvBook;
    private TextView tvPage;
    private TextView tvKitchen;
    private TextView tvCourse;
    private TextView tvTime;
    private TextView tvPersons;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recipe);

        navigationMenuTitles = getResources().getStringArray(R.array.navigation_titles);
        navigationMenuIcons = getResources().obtainTypedArray(R.array.navigation_icons);
        set(navigationMenuTitles, navigationMenuIcons);

        SQLiteDatabase mDatabase = openOrCreateDatabase("RecipeFinderDB", MODE_PRIVATE, null);
        mDatabaseConnection = new DatabaseConnection(mDatabase, this);

        initializeLayout();

        Intent mIntent = getIntent();
        int recipeId = mIntent.getIntExtra("id", -1);
        if (recipeId == -1)
            throw new IndexOutOfBoundsException("No id is given.");

        mRecipe = getRecipe(recipeId);
        loadRecipe();

        Ingredient[] mIngredients = mDatabaseConnection.getIngredientsOfRecipe(recipeId);
        IngredientListAdapter mIngredientAdapter = new IngredientListAdapter(this, mIngredients);
        lvIngredients.setAdapter(mIngredientAdapter);

        Allergy[] mAllergies = mDatabaseConnection.getAllergiesOfRecipe(recipeId);
        AllergyListAdapter mAllergyAdapter = new AllergyListAdapter(this, mAllergies);
        lvAllergies.setAdapter(mAllergyAdapter);
    }

    private void initializeLayout() {
        bTabDetails = (Button) findViewById(R.id.bTabDetails);
        bTabDetails.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                switchView(RecipeViews.DETAILS);
            }
        });
        bTabAllergies = (Button) findViewById(R.id.bTabAllergies);
        bTabAllergies.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) { switchView(RecipeViews.ALLERGIES);}
        });
        bTabIngredients = (Button) findViewById(R.id.bTabIngredients);
        bTabIngredients.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) { switchView(RecipeViews.INGREDIENTS);
            } });

        tlDetails = (TableLayout) findViewById(R.id.tlDetails);
        lvAllergies = (ListView) findViewById(R.id.lvAllergies);
        lvIngredients = (ListView) findViewById(R.id.lvIngredients);

        tvTitle = (TextView) findViewById(R.id.tvTitle);
        tvBook = (TextView) findViewById(R.id.tvBook);
        tvPage = (TextView) findViewById(R.id.tvPage);
        tvKitchen = (TextView) findViewById(R.id.tvKitchen);
        tvCourse = (TextView) findViewById(R.id.tvCourse);
        tvTime = (TextView) findViewById(R.id.tvTime);
        tvPersons = (TextView) findViewById(R.id.tvPersons);
    }

    private void switchView(RecipeViews view){
        bTabDetails.setBackgroundColor(Color.WHITE);
        bTabAllergies.setBackgroundColor(Color.WHITE);
        bTabIngredients.setBackgroundColor(Color.WHITE);

        tlDetails.setVisibility(View.GONE);
        lvAllergies.setVisibility(View.GONE);
        lvIngredients.setVisibility(View.GONE);

        switch (view){
            case DETAILS:
                bTabDetails.setBackgroundColor(Color.parseColor("#aaaaaa"));
                tlDetails.setVisibility(View.VISIBLE);
                break;
            case ALLERGIES:
                bTabAllergies.setBackgroundColor(Color.parseColor("#aaaaaa"));
                lvAllergies.setVisibility(View.VISIBLE);
                break;
            case INGREDIENTS:
                bTabIngredients.setBackgroundColor(Color.parseColor("#aaaaaa"));
                lvIngredients.setVisibility(View.VISIBLE);
                break;
        }
    }

    private void loadRecipe() {
        tvTitle.setText(mRecipe.getTitle());
        tvBook.setText(mRecipe.getBook());
        tvPage.setText("" + mRecipe.getPage());
        tvKitchen.setText(mRecipe.getKitchen());
        tvCourse.setText(mRecipe.getCourse());
        tvTime.setText("" + mRecipe.getPreperationTime() + " minuten");
        tvPersons.setText("" + mRecipe.getPersons());
    }

    private void changeFavorite(boolean value) {
        int iValue = 0;
        if (value)
            iValue = 1;

        mDatabaseConnection.executeNonReturn("UPDATE recipes SET favorite = '" + iValue + "' WHERE id = " + mRecipe.getId());
    }

    private void changeHide(boolean value) {
        int iValue = 0;
        if (value)
            iValue = 1;

        mDatabaseConnection.executeNonReturn("UPDATE recipes SET hide = '" + iValue + "' WHERE id = " + mRecipe.getId());
    }

    private Recipe getRecipe(int recipeId) {
        Recipe[] recipes = mDatabaseConnection.loadRecipes("SELECT * FROM recipes WHERE id = " + recipeId);
        Recipe mRecipe = null;

        if (recipes.length == 0)
            throw new IndexOutOfBoundsException("Recipe with id '" + recipeId + "' not found.");
        else
            mRecipe = recipes[0];

        return mRecipe;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_recipe, menu);

        MenuItem cbFavorite = menu.findItem(R.id.cbFavorite);
        MenuItem bHide = menu.findItem(R.id.bHide);

        if (mRecipe.isFavorite())
            cbFavorite.setIcon(getResources().getDrawable(R.drawable.abc_btn_rating_star_on_mtrl_alpha));
        else
            cbFavorite.setIcon(getResources().getDrawable(R.drawable.abc_btn_rating_star_off_mtrl_alpha));

        if(mRecipe.isHidden())
            bHide.setTitle(R.string.unhide);
        else
            bHide.setTitle(R.string.hide);

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(final MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.cbFavorite) {
            if (mRecipe.isFavorite()) {
                mRecipe.setFavorite(false);
                changeFavorite(false);
                item.setIcon(getResources().getDrawable(R.drawable.abc_btn_rating_star_off_mtrl_alpha));
            } else {
                mRecipe.setFavorite(true);
                changeFavorite(true);
                item.setIcon(getResources().getDrawable(R.drawable.abc_btn_rating_star_on_mtrl_alpha));
            }
        }

        if (id == R.id.bHide) {
            AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(this);

            if(mRecipe.isHidden()) {
                dialogBuilder.setMessage(R.string.unhide_warning);

                dialogBuilder.setPositiveButton(R.string.unhide, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        changeHide(false);
                        item.setTitle(R.string.hide);
                        mRecipe.setHidden(false);
                    }
                });

                dialogBuilder.setNegativeButton(R.string.cancel, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                    }
                });
            }
            else {
                dialogBuilder.setMessage(R.string.hide_warning);

                dialogBuilder.setPositiveButton(R.string.hide, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        changeHide(true);
                        item.setTitle(R.string.unhide);
                        mRecipe.setHidden(true);
                    }
                });

                dialogBuilder.setNegativeButton(R.string.cancel, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                    }
                });
            }

            dialogBuilder.show();
        }

        return super.onOptionsItemSelected(item);
    }
}