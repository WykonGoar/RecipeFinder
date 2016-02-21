package com.wykon.recipefinder.model.objects;

/**
 * Created by Wouter on 14-2-2016.
 */
public class Allergy {
    private int mId;
    private String mName;

    public Allergy(int id, String name) {
        mId = id;
        mName = name;
    }

    public int getId() {
        return mId;
    }

    public String getName() {
        return mName;
    }

    public String getUpdateQuery(){
        String query = "UPDATE allergies SET name = '" + mName + "' WHERE _id = " + mId ;
        return query;
    }
}
