using System;
using System.Collections.Generic;
using Godot;

public class Farm {

    private Dictionary<Vector2I, Tile> _farmTiles;

    public Farm(Vector2I[] tileCoordArray, tile_map_controller visualTileMap) {
        _farmTiles = new Dictionary<Vector2I, Tile>();

        // Maps out the entire farm-tile system, including adjacencies

        Dictionary<Vector2I, Vector2I[]> adjMap = new Dictionary<Vector2I, Vector2I[]>();
 

        foreach(Vector2I coord in tileCoordArray){
            Vector2I[] adjacentTiles = visualTileMap.GetCellNeighbors(coord); 

            adjMap.Add(coord, adjacentTiles);
            _farmTiles.Add(coord, new Tile(null, null));
        }

        foreach(Vector2I coord in adjMap.Keys){
            Vector2I[] values = adjMap[coord]; 
            Tile[] adj = new Tile[values.Length];

            for(int i = 0; i < values.Length; i++){
                if(values[i].Equals(Vector2I.MinValue)) continue;
                adj[i] = _farmTiles[values[i]];
            }
            _farmTiles[coord].SetAdjacentTiles(adj);
        }

        GD.Print("TILES INSTANTIATED");

        int tNum = 1; 
        foreach(Vector2I key in _farmTiles.Keys){

            string print = $"{tNum}: ({key.X}, {key.Y}): adjacent = ";

            foreach(Tile t in _farmTiles[key].GetAdjacentTiles()){
                if(t != null){
                    print += t.ToString() + ", ";
                }
            }
            GD.Print(print);
            tNum++;
        }

    }
}