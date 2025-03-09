using Godot;
using System;
using System.Collections.Generic;

public class PlayerCardDeck : ICardDeck{

    private List<ICard> _cardList;

    public ICard[] CardList{
        get => _cardList.ToArray();
    }

    public PlayerCardDeck(ICard[] cards, bool shuffle){
        _cardList = new List<ICard>();
        _cardList.AddRange(cards);

        if(shuffle) Shuffle();
    }


    public void Shuffle(){
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
            GD.PrintErr("ERROR::PlayerCardDeck::GetCardByIndex() : INVALID INDEX " + index);
        }
        else{
            outCard = _cardList[index];
        }

        return outCard;
    }
	
	public void AddCard(ICard card){
        _cardList.Add(card);
    }

	public void RemoveCard(ICard card){
        _cardList.Remove(card);
    }

}