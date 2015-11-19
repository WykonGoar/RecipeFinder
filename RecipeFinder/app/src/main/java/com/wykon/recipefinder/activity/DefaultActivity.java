package com.wykon.recipefinder.activity;

import android.content.Intent;
import android.content.res.Configuration;
import android.content.res.TypedArray;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import com.wykon.recipefinder.R;
import com.wykon.recipefinder.model.DatabaseConnection;
import com.wykon.recipefinder.model.IORecipes;
import com.wykon.recipefinder.model.NavigationItem;
import com.wykon.recipefinder.model.NavigationListAdapter;

import java.util.ArrayList;

/**
 * Created by Wouter on 28-8-2015.
 */
public class DefaultActivity extends AppCompatActivity {
    private DrawerLayout mDrawerLayout;
    private ListView mDrawerList;
    private ActionBarDrawerToggle mDrawerToggle;

    private  int currentActivityPosition = 0;
    // nav drawer title
    private String mDrawerTitle;

    // used to store app title
    private String mTitle;

    private ArrayList<NavigationItem> navDrawerItems;
    private NavigationListAdapter adapter;

    private DatabaseConnection mDatabaseConnection;
    private IORecipes mIoRecipes;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_default);

        SQLiteDatabase mDatabase = openOrCreateDatabase("RecipeFinderDB", MODE_PRIVATE, null);
        mDatabaseConnection = new DatabaseConnection(mDatabase, this);

        mIoRecipes = new IORecipes(this, mDatabaseConnection);
    }

    public void set(String[] navMenuTitles,TypedArray navMenuIcons){
        mDrawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout);
        mDrawerList = (ListView) findViewById(R.id.left_drawer);

        navDrawerItems = new ArrayList<NavigationItem>();

        // adding nav drawer items
        if(navMenuIcons==null){
            for(int i=0;i<navMenuTitles.length;i++){
                navDrawerItems.add(new NavigationItem(navMenuTitles[i]));
            }}else{
            for(int i=0;i<navMenuTitles.length;i++){
                navDrawerItems.add(new NavigationItem(navMenuTitles[i],navMenuIcons.getResourceId(i, -1)));
            }
        }

        mDrawerList.setOnItemClickListener(new SlideMenuClickListener());

        // setting the nav drawer list adapter
        adapter = new NavigationListAdapter(getApplicationContext(),
                navDrawerItems);
        mDrawerList.setAdapter(adapter);

        // enabling action bar app icon and behaving it as toggle button
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setIcon(R.drawable.app_icon);

        mDrawerTitle = getResources().getString(R.string.app_name);
        mTitle = navDrawerItems.get(currentActivityPosition).getTitle();

        mDrawerToggle = new ActionBarDrawerToggle(this, mDrawerLayout,
                R.string.app_name, // nav drawer open - description for
                // accessibility
                R.string.app_name // nav drawer close - description for
                // accessibility
        ) {
            public void onDrawerClosed(View view) {
                getSupportActionBar().setTitle(mTitle);
                // calling onPrepareOptionsMenu() to show action bar icons
                supportInvalidateOptionsMenu();
            }

            public void onDrawerOpened(View drawerView) {
                getSupportActionBar().setTitle(mDrawerTitle);
                // calling onPrepareOptionsMenu() to hide action bar icons
                supportInvalidateOptionsMenu();
            }
        };

        mDrawerToggle.setDrawerIndicatorEnabled(true);
        mDrawerLayout.setDrawerListener(mDrawerToggle);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setHomeButtonEnabled(true);
    }

    private class SlideMenuClickListener implements
            ListView.OnItemClickListener {
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position,
                                long id) {
            // display view for selected nav drawer item
            displayView(position);
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // getSupportMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        if (item.getItemId() == android.R.id.home) {
            if (mDrawerLayout.isDrawerOpen(mDrawerList)) {
                mDrawerLayout.closeDrawer(mDrawerList);
            } else {
                mDrawerLayout.openDrawer(mDrawerList);
            }
        }

        return super.onOptionsItemSelected(item);
    }

    /***
     * Called when invalidateOptionsMenu() is triggered
     */
    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {
        // if nav drawer is opened, hide the action items
        // boolean drawerOpen = mDrawerLayout.isDrawerOpen(mDrawerList);
        // menu.findItem(R.id.action_settings).setVisible(!drawerOpen);
        return super.onPrepareOptionsMenu(menu);
    }

    /**
     * Diplaying fragment view for selected nav drawer list item
     * */
    private void displayView(int position) {
        // update the main content by replacing fragments
        Intent mIntent = null;
        switch (position) {
            case 0:
                currentActivityPosition = 0;
                mIntent = new Intent(this, RecipeListActivity.class);
                startActivity(mIntent);
                finish();
                break;
            case 1:
                currentActivityPosition = 1;
                mIntent = new Intent(this, FavoriteListActivity.class);
                startActivity(mIntent);
                finish();
                break;
            case 2:
                currentActivityPosition = 2;
                mIntent = new Intent(this, SearchActivity.class);
                startActivity(mIntent);
                finish();
                break;
            case 3:
                currentActivityPosition = 3;
                mIntent = new Intent(this, RandomActivity.class);
                startActivity(mIntent);
                finish();
                break;
            case 4:
                currentActivityPosition = 4;
                mIntent = new Intent(this, HiddenRecipeList.class);
                startActivity(mIntent);
                finish();
                break;
            case 5:
                if(mIoRecipes.importRecipes()) {
                    Toast.makeText(this, "Recepten zijn geimporteerd", Toast.LENGTH_LONG).show();
                    displayView(0);
                }else
                    Toast.makeText(this, "Mislukt", Toast.LENGTH_LONG).show();
                break;
            case 6:
                if(mIoRecipes.exportRecipes())
                    Toast.makeText(this, "Recepten zijn geexporteerd", Toast.LENGTH_LONG).show();
                else
                    Toast.makeText(this, "Mislukt", Toast.LENGTH_LONG).show();
                break;
            default:
                currentActivityPosition= 0;
                mIntent = new Intent(this, RecipeListActivity.class);
                startActivity(mIntent);
                finish();
                break;
        }

        // update selected item and title, then close the drawer
        mDrawerList.setItemChecked(position, true);
        mDrawerList.setSelection(position);
        mDrawerLayout.closeDrawer(mDrawerList);
    }

    @Override
    public void setTitle(CharSequence title) {

        getActionBar().setTitle(mTitle);
    }

    /**
     * When using the ActionBarDrawerToggle, you must call it during
     * onPostCreate() and onConfigurationChanged()...
     */

    @Override
    protected void onPostCreate(Bundle savedInstanceState) {
        super.onPostCreate(savedInstanceState);
        // Sync the toggle state after onRestoreInstanceState has occurred.
        mDrawerToggle.syncState();
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
        // Pass any configuration change to the drawer toggls
        mDrawerToggle.onConfigurationChanged(newConfig);
    }
}