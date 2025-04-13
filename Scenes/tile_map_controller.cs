using Godot;
using System;

public partial class tile_map_controller : TileMapLayer
{
	private Vector2I selectedTile;
	private Vector2I hoveredTile;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("test");
		selectedTile.X = 10;
		selectedTile.Y = 10;
		hoveredTile.X = 11;
		hoveredTile.Y = 11;
	}

	public override void _Process(double delta)
	{
		Vector2I temp = new Vector2I(0, 1);
		SetCell(selectedTile, 0, temp, 0);
	}

	public override void _Input(InputEvent @event) {
		if (@event is InputEventMouseMotion eventMouseMotion)
		{
			Vector2I atlasPosition = GetCellAtlasCoords(hoveredTile);
			atlasPosition.Y = 2;
			SetCell(hoveredTile, 0, atlasPosition, 0);
			hoveredTile = LocalToMap(ToLocal(eventMouseMotion.Position));		
			atlasPosition = GetCellAtlasCoords(hoveredTile);
			atlasPosition.Y = 3;
			SetCell(hoveredTile, 0, atlasPosition, 0);
			
		}
		
		//algorithm for selecting a tile by clicking
		if (@event is InputEventMouseButton eventMouseButton)
		{
			if (eventMouseButton.ButtonIndex == MouseButton.Left && @event.IsPressed())
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
