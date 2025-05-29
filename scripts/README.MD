# README.MD:


## MECHANICS:

### CARD Selection and playing:
    1. PHandUIHandler creates a bunch of callbacks that are invoked when a card is selected via ui
    2. one of these callbacks sets the currently selected card (_selectedCard field) in player 
    3. tile_map_controller, which has a reference to the current player instance, plays the selected card on the tile the player clicks on (Player.PlaySelectedCardOnTile)
