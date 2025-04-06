public class Plant {

    private string name;
    private int value;
    private int seasonFlags;
    private int growTime;
    private int waterRate;
    private int harvestRate;

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