package com.wykon.recipefinder.model;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.wykon.recipefinder.R;

import java.util.ArrayList;

/**
 * Created by Wouter on 31-8-2015.
 */
public class NavigationListAdapter extends BaseAdapter{
    private Context mContext;
    private ArrayList<NavigationItem> mNavigationItems;

    public NavigationListAdapter(Context context, ArrayList<NavigationItem> navDrawerItems){
        mContext = context;
        mNavigationItems = navDrawerItems;
    }

    @Override
    public int getCount() {
        return mNavigationItems.size();
    }

    @Override
    public Object getItem(int position) {
        return mNavigationItems.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if (convertView == null) {
            LayoutInflater mInflater = (LayoutInflater)
                    mContext.getSystemService(Activity.LAYOUT_INFLATER_SERVICE);
            convertView = mInflater.inflate(R.layout.navigation_row, null);
        }

        ImageView mImageView = (ImageView) convertView.findViewById(R.id.icon);
        TextView mTextView = (TextView) convertView.findViewById(R.id.title);

        mImageView.setImageResource(mNavigationItems.get(position).getIcon());
        mTextView.setText(mNavigationItems.get(position).getTitle());

        return convertView;
    }
}
