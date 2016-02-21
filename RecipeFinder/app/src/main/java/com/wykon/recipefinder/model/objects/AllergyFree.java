package com.wykon.recipefinder.model.objects;

/**
 * Created by Wouter on 14-2-2016.
 */
public class AllergyFree {
    private int mId;
    private String mName;
    private boolean mFree;

    public AllergyFree(int id, String name) {
        mId = id;
        mName = name;
        mFree = false;
    }

    public AllergyFree(Allergy allergy)
    {
        mId = allergy.getId();
        mName = allergy.getName();
        mFree = false;
    }

    public int getId() {
        return mId;
    }

    public String getName() {
        return mName;
    }

    public boolean isFree(){return mFree;}

    public void setFree(boolean free){
        mFree = free;
    }
}
