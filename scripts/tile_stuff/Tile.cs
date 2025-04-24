using Godot;

public class Tile {

    private Tile[] _adjacent;
    private Plant _plant;

    /// <summary>
    /// Instantiate a new empty tile
    /// </summary>
    public Tile(Tile[] adjacentTiles, Plant p) { 
        _adjacent = adjacentTiles;
        _plant = p;
    }


    public void SetAdjacentTiles(Tile[] adjacent){
        this._adjacent = adjacent;
    }

    public void SetPlant(Plant p){
        this._plant = p;
    }

    public Tile[] GetAdjacentTiles(){
        return _adjacent;
    }

    public Plant GetPlant(){
        return _plant;
    }

}