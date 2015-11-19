package com.wykon.recipefinder.model;

/**
 * Created by Wouter on 24-8-2015.
 */
public class Recipe {

    private int mId = -1;
    private String mBook;
    private int mPage = 0;
    private String mKitchen;
    private String mCourse;
    private String mTitle;
    private int mPreperationTime = 0;
    private int mPersons = 0;
    private boolean mFavorite = false;
    private boolean mLactoseFree = false;
    private boolean mGlutenFree = false;
    private boolean mHide = false;

    public Recipe(int id, String book, int page, String kitchen, String course, String title, int preperationTime, int persons, boolean favorite, boolean lactoseFree, boolean glutenFree, boolean hide) {
        mId = id;
        mBook = book;
        mPage = page;
        mKitchen = kitchen;
        mCourse = course;
        mTitle = title;
        mPreperationTime = preperationTime;
        mPersons = persons;
        mFavorite = favorite;
        mLactoseFree = lactoseFree;
        mGlutenFree = glutenFree;
        mHide = hide;
    }

    public int getId() {
        return mId;
    }

    public String getBook() {
        return mBook;
    }

    public int getPage() {
        return mPage;
    }

    public String getKitchen() {
        return mKitchen;
    }

    public String getCourse() {
        return mCourse;
    }

    public String getTitle() {
        return mTitle;
    }

    public int getPreperationTime() {
        return mPreperationTime;
    }

    public int getPersons() {
        return mPersons;
    }

    public  boolean isFavorite() {
        return  mFavorite;
    }

    public boolean isGlutenFree() {
        return mGlutenFree;
    }

    public boolean isLactoseFree() {
        return mLactoseFree;
    }

    public boolean isHidden() {return mHide; }

    public void setId(int id) { mId = id; }

    public void setBook(String book) {
        mBook = book;
    }

    public void setPage(int page) {
        mPage = page;
    }

    public void setKitchen(String kitchen) {
        mKitchen = kitchen;
    }

    public void setCourse(String course) {
        mCourse = course;
    }

    public void setTitle(String title) {
        mTitle = title;
    }

    public void setPreperationTime(int preperationTime) {
        mPreperationTime = preperationTime;
    }

    public void setPersons(int persons) {
        mPersons = persons;
    }

    public void setFavorite(boolean favorite) {
        mFavorite = favorite;
    }

    public void setLactoseFree(boolean lactoseFree) {
        mLactoseFree = lactoseFree;
    }

    public void setGlutenFree(boolean glutenFree) {
        mGlutenFree = glutenFree;
    }

    public void setHidden(boolean hidden) { mHide = hidden;}

    public String getUpdateQuery(){
        int iFavorite = 0;
        if(mFavorite)
            iFavorite = 1;

        int iLactoseFree = 0;
        if(mLactoseFree)
            iLactoseFree = 1;

        int iGlutenFree = 0;
        if(mGlutenFree)
            iGlutenFree = 1;

        int iHide = 0;
        if(mHide)
            iHide = 1;

        String query = "UPDATE recipes SET book = '" + mBook + "', page = " + mPage + ", kitchen = '" + mKitchen + "', course = '" + mCourse + "',title = '" + mTitle + "', maxPreperationTime = " + mPreperationTime + ",persons = " + mPersons + ",favorite = " + iFavorite + ",lactosefree = " + iLactoseFree + ",glutenfree = " + iGlutenFree + ", hide = " + iHide + " WHERE _id = " +mId ;
        return query;
    }
}
