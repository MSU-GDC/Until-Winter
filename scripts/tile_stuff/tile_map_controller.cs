using Godot;
using System;
using System.Linq;

public partial class tile_map_controller : TileMapLayer
{
	private Vector2I selectedTile;
	private Vector2I hoveredTile;

	private Godot.Collections.Array<Vector2I> _usedTiles;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("test");
		selectedTile.X = 0;
		selectedTile.Y = 0;
		hoveredTile.X = 0;
		hoveredTile.Y = 0;
		
		_usedTiles = GetUsedCells();

		int i = 0;
		foreach(Vector2I v2 in _usedTiles){
			GD.Print($"{i}: {v2.X}, {v2.Y}");
			i++;
		}
	}

	public override void _Process(double delta)
	{
		Vector2I temp = new Vector2I(0, 1);
		SetCell(selectedTile, 0, temp, 0);
		GD.Print($"Hovered tile coords {hoveredTile.X}, {hoveredTile.Y}");
	}

	public override void _Input(InputEvent @event) {
		if (@event is InputEventMouseMotion eventMouseMotion)
		{
			Vector2I atlasPosition = GetCellAtlasCoords(hoveredTile);
			// set previously hovered tile sprite to be unhighlighted
			atlasPosition.Y = 2;
			SetCell(hoveredTile, 0, atlasPosition, 0); 
			hoveredTile = LocalToMap(ToLocal(eventMouseMotion.Position));	

			
			// if the newly hovered tile is not a used tile 
			if(_usedTiles.Contains(hoveredTile)){
				atlasPosition = GetCellAtlasCoords(hoveredTile);
				atlasPosition.Y = 3;
				SetCell(hoveredTile, 0, atlasPosition, 0);
			}	

		}
		
		//algorithm for selecting a tile by clicking
		if (@event is InputEventMouseButton eventMouseButton)
		{
			if (eventMouseButton.ButtonIndex == MouseButton.Left && @event.IsPressed() && _usedTiles.Contains(hoveredTile))
			{
				//this chunk deselects the previous tile
				Vector2I atlasPosition = GetCellAtlasCoords(selectedTile);
				atlasPosition.Y = 2;
				SetCell(selectedTile, 0, atlasPosition, 0);

				//this chunk selects the new tile
				selectedTile = LocalToMap(ToLocal(eventMouseButton.Position));
				atlasPosition = GetCellAtlasCoords(selectedTile);
				atlasPosition.Y = 1;
				SetCell(selectedTile, 0, atlasPosition, 0);
			}
		}		
	}
}
