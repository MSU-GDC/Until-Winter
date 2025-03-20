using Godot; 
using System;

/// <summary>
/// CardHand.cs:
/// A card hand is similar to a card deck except it has a hard limit on the amount of cards that it can contain. 
/// This limit is given by the HAND_SIZE_LIMIT constant.
/// -- John
/// </summary>
public class CardHand : ICardDeck
{
    public const int HAND_SIZE_LIMIT = 5; //poker rules babyyyy

    private ICard[] _hand;

    private int _firstEmptyIndex;


    public ICard[] Cards {get => _hand;}

    public CardHand(ICard[] cards, bool shuffle)
    {
        _hand = cards;

        Array.Resize(ref _hand,HAND_SIZE_LIMIT);

        _firstEmptyIndex = Math.Min(cards.Length,HAND_SIZE_LIMIT);

        if(shuffle) Shuffle();

    }
    public bool AddCard(ICard card)
    {   
        bool result = false;
        if(_firstEmptyIndex < HAND_SIZE_LIMIT){
            _hand[_firstEmptyIndex] = card;
            _firstEmptyIndex++;
            result = true;
        }

        return result;
    }
    /// <summary>
    /// removes the first instance of the specified card and formats the hand accordingly
    /// </summary>
    /// <param name="card"> the card to be removed</param>
    /// <returns>true if the instance exists and/or has been removed from the hand, false if otherwise</returns>
    public bool RemoveCard(ICard card)
    {
        bool instanceRemoved = false;

        int staggeredIndex = 0;
        
        ICard[] resultHand = new ICard[HAND_SIZE_LIMIT];
        for(int i = 0; i < HAND_SIZE_LIMIT; i++){

            if(instanceRemoved || !_hand[i].Equals(card)){
                resultHand[staggeredIndex] = _hand[i];
                staggeredIndex++;
            }
            else{
                instanceRemoved = true;
            }
        }
        _firstEmptyIndex--;

        return instanceRemoved;

    }
    /// <summary>
    /// Gets the first instance of a card with the specified ID
    /// </summary>
    /// <param name="id">the id of the card</param>
    /// <returns>null if the card does not exist in the hand, otherwise it returns the card</returns>
    public ICard GetCardByID(CardID id)
    {
        ICard card = null;

        for(int i = 0; i < _firstEmptyIndex; i++){
            if(_hand[i].GetID() == id){
                card = _hand[i];
                break;
            }
        }
        return card;
    }

    public ICard GetCardByIndex(int index)
    {
        if(index >= HAND_SIZE_LIMIT) return null;
        else return(_hand[index]);
    }

    public void Shuffle()
    {
        if(_firstEmptyIndex == 0) return; // empty hand


        ICard[] cardArr = _hand;


        Random rng = new Random();
        
        ICard iCard;
        ICard tempCard;

        int tempIndex;

        for(int i = 0; i < _firstEmptyIndex; i++){

            iCard = cardArr[i];

            tempIndex = rng.Next(_firstEmptyIndex);

            tempCard = cardArr[tempIndex];

            cardArr[i] = tempCard;

            cardArr[tempIndex] = iCard;
        }

        _hand = cardArr;
        
    }
}