package com.wykon.recipefinder.model.activitylists;

import android.content.Context;
import android.provider.ContactsContract;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

import com.wykon.recipefinder.R;
import com.wykon.recipefinder.model.objects.Allergy;

import java.util.HashMap;
import java.util.List;

/**
 * Created by Wouter on 25-8-2015.
 */
public class AllergyFreeListAdapter extends ArrayAdapter<Allergy> {

    private Context mContext;
    private Allergy[] mAllergies;

    public AllergyFreeListAdapter(Context context, Allergy[] objects) {
        super(context, R.layout.row_allergy_free, objects);

        mContext = context;
        mAllergies = objects;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        LayoutInflater mLayoutInflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rowView = mLayoutInflater.inflate(R.layout.row_allergy_free, parent, false);

        TextView tvName = (TextView) rowView.findViewById(R.id.tvName);

        Allergy mAllergy = mAllergies[position];
        tvName.setText(mAllergy.getName());

        return  rowView;
    }
}
