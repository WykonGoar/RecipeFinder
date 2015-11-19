package com.wykon.recipefinder.model;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.wykon.recipefinder.R;

/**
 * Created by Wouter on 24-8-2015.
 */
public class RecipeListAdapter extends ArrayAdapter<Recipe> {

    private  Context mContext;
    private  Recipe[] mRecipes;

    public RecipeListAdapter(Context context, Recipe[] objects) {
        super(context, R.layout.recipe_row, objects);

        mContext = context;
        mRecipes = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        LayoutInflater mLayoutInflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rowView = mLayoutInflater.inflate(R.layout.recipe_row, parent, false);

        TextView tvTitle = (TextView) rowView.findViewById(R.id.tvTitle);
        TextView tvKitchen = (TextView) rowView.findViewById(R.id.tvKitchen);
        TextView tvCourse = (TextView) rowView.findViewById(R.id.tvCourse);
        TextView tvTime = (TextView) rowView.findViewById(R.id.tvTime);

        Recipe mRecipe = mRecipes[position];
        tvTitle.setText(mRecipe.getTitle());
        tvKitchen.setText(mRecipe.getKitchen());
        tvCourse.setText(mRecipe.getCourse());
        tvTime.setText(mRecipe.getPreperationTime() + " min");

        return  rowView;
    }
}
