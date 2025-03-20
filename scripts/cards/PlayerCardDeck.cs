using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// Card pool used by the player throughout the game. 
/// This deck will change contents regularly, sometimes it might be required to wipe the deck (eg in the case of a season change) and re-fill it with new cards.
/// -- John
/// </summary>
public class PlayerCardDeck : ICardDeck{

    private List<ICard> _cardList;

    public ICard[] CardList{
        get => _cardList.ToArray();
    }

    public PlayerCardDeck(ICard[] cards, bool shuffle){
        _cardList = new List<ICard>();
        if(cards != null) _cardList.AddRange(cards);
 
        if(shuffle) Shuffle();
    }


    public void Shuffle(){
        if(_cardList.Count == 0) return;

        ICard[] cardArr = _cardList.ToArray();

        Random rng = new Random();
        
        ICard iCard;
        ICard tempCard;

        int tempIndex;

        for(int i = 0; i < cardArr.Length; i++){

            iCard = cardArr[i];

            tempIndex = rng.Next(cardArr.Length);

            tempCard = cardArr[tempIndex];

            cardArr[i] = tempCard;

            cardArr[tempIndex] = iCard;
        }


    }

	public ICard GetCardByIndex(int index){
        ICard outCard =  null;
        if(index >= _cardList.Count){
            GD.PrintErr("ERROR::PlayerCardDeck::GetCardByIndex() : INVALID INDEX " + index + " FOR DECK OF SIZE " + _cardList.Count);
        }
        else{
            outCard = _cardList[index];
        }

        return outCard;
    }
	
	public bool AddCard(ICard card){
        _cardList.Add(card);
        return true;
    }

	public bool RemoveCard(ICard card){
        return _cardList.Remove(card);
    }

    public ICard GetCardByID(CardID id){
        foreach(ICard card in _cardList){
            if(card.GetID().Equals(id)) return card;
        }
        return null;
    }

}