package com.wykon.recipefinder.model.activitylists;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.wykon.recipefinder.R;
import com.wykon.recipefinder.model.objects.Allergy;
import com.wykon.recipefinder.model.objects.Ingredient;

/**
 * Created by Wouter on 25-8-2015.
 */
public class AllergyListAdapter extends ArrayAdapter<Allergy> {

    private Context mContext;
    private Allergy[] mAllergies;

    public AllergyListAdapter(Context context, Allergy[] objects) {
        super(context, R.layout.row_allergy, objects);

        mContext = context;
        mAllergies = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        LayoutInflater mLayoutInflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rowView = mLayoutInflater.inflate(R.layout.row_allergy, parent, false);

        TextView tvName = (TextView) rowView.findViewById(R.id.tvName);

        Allergy mAllergy = mAllergies[position];
        tvName.setText(mAllergy.getName());

        return  rowView;
    }
}
