package com.wykon.recipefinder.model;

import java.text.DecimalFormat;

/**
 * Created by Wouter on 25-8-2015.
 */
public class Ingredient {

    private int mId;
    private int mRecipeId;
    private String mName;
    private double mAmount;
    private String mMeasure;

    public Ingredient(String name, double amount, String measure) {
        mName = name;
        mAmount = amount;
        mMeasure = measure;
    }

    public Ingredient(int id, int recipeId, String name, double amount, String measure) {
        mId = id;
        mRecipeId = recipeId;
        mName = name;
        mAmount = amount;
        mMeasure = measure;
    }

    public int getId() {
        return mId;
    }

    public int getRecipeId() {
        return mRecipeId;
    }

    public String getName() {
        return mName;
    }

    public double getAmount() {
        return mAmount;
    }

    public String getMeasure() {
        return mMeasure;
    }

    public String getIngredientAmount(){
        String amount = "";
        String measure = "";

        if(mAmount != 0.0) {
            DecimalFormat decimalFormat = new DecimalFormat("#.#");
            amount = decimalFormat.format(mAmount);
        }
        if(mMeasure != null)
            measure = mMeasure;

        return amount + " " + measure;
    }

    public String getUpdateQuery(){
        String query = "UPDATE ingredients SET recipeId = " + mRecipeId + ", name = '" + mName + "', amount = '" + mAmount + "', measure = '" + mMeasure + "' WHERE _id = " + mId ;
        return query;
    }
}
