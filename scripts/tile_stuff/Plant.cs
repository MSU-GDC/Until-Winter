using Godot;
using System;
public partial class Plant : Resource {

    [ExportGroup("Fields")]
    [Export] private string name;
    [Export] private int value;
    [Export] private int seasonFlags;
    [Export] private int growTime;
    [Export] private int waterRate;
    [Export] private int harvestRate;

    public Plant(string n, int v, int f, int gt, int wr, int hr) {
        name = n;
        value = v;
        seasonFlags = f;
        growTime = gt;
        waterRate = wr;
        harvestRate = hr; 
    }

    public string getName() {
        return name;
    }

    public int getValue() {
        return value;
    }

    public int getSeasons() {
        return seasonFlags;
    }

    public int getGrowTime() {
        return growTime;
    }

    public int getWaterRate() {
        return waterRate;
    }

    public int getHarvestRate() {
        return harvestRate;
    }
}

public enum SeasonFlags{
    NONE = 0b0000,
    SPRING = 0b0001,
    SUMMER = 0b0010,
    AUTUMN = 0b0100,
    WINTER = 0b1000
}