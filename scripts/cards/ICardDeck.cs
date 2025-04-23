using Godot;
using System;

public interface ICardDeck
{
	public void Shuffle();

	public ICard GetCardByIndex(int index);

	public ICard GetCardByID(CardID id);

	public bool AddCard(ICard card);

	public bool RemoveCard(ICard card);
}
