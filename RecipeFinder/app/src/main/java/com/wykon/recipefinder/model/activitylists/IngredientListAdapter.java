package com.wykon.recipefinder.model.activitylists;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.wykon.recipefinder.R;
import com.wykon.recipefinder.model.objects.Ingredient;

/**
 * Created by Wouter on 25-8-2015.
 */
public class IngredientListAdapter extends ArrayAdapter<Ingredient> {

    private Context mContext;
    private Ingredient[] mIngredients;

    public IngredientListAdapter(Context context, Ingredient[] objects) {
        super(context, R.layout.row_ingredient, objects);

        mContext = context;
        mIngredients = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        LayoutInflater mLayoutInflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rowView = mLayoutInflater.inflate(R.layout.row_ingredient, parent, false);

        TextView tvName = (TextView) rowView.findViewById(R.id.tvName);
        TextView tvAmount = (TextView) rowView.findViewById(R.id.tvAmount);

        Ingredient mIngredient = mIngredients[position];
        tvName.setText(mIngredient.getName());
        tvAmount.setText(mIngredient.getIngredientAmount());

        return  rowView;
    }
}
