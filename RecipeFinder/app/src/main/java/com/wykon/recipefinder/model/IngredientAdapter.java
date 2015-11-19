package com.wykon.recipefinder.model;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.wykon.recipefinder.R;

/**
 * Created by Wouter on 25-8-2015.
 */
public class IngredientAdapter extends ArrayAdapter<Ingredient> {

    private Context mContext;
    private Ingredient[] mIngredients;

    public IngredientAdapter(Context context, Ingredient[] objects) {
        super(context, R.layout.ingredient_row, objects);

        mContext = context;
        mIngredients = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        LayoutInflater mLayoutInflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rowView = mLayoutInflater.inflate(R.layout.ingredient_row, parent, false);

        TextView tvName = (TextView) rowView.findViewById(R.id.tvName);
        TextView tvAmount = (TextView) rowView.findViewById(R.id.tvAmount);

        Ingredient mIngredient = mIngredients[position];
        tvName.setText(mIngredient.getName());
        tvAmount.setText(mIngredient.getIngredientAmount());

        return  rowView;
    }
}
