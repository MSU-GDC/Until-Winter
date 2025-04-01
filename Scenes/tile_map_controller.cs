using Godot;
using System;

public partial class tile_map_controller : TileMapLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("test");
	}

	public override void _Input(InputEvent @event) {
		//algorithm for selecting a tile by clicking
		if (@event is InputEventMouseButton eventMouseButton)
		{
			if (eventMouseButton.ButtonIndex == MouseButton.Left && @event.IsPressed())
			{
				//sets the global position of the click relative to the grid
				Vector2I position = LocalToMap(ToLocal(eventMouseButton.Position));
				//gets the selected cell's position within the atlas
				Vector2I atlasPosition = GetCellAtlasCoords(position);
				//sets the new atlas position
				atlasPosition.Y--;
				//changes the tile's appearance
				SetCell(position, 0, atlasPosition, 0);
			}
		}
	}
	
}
