using Godot;
using System;

public interface ICardDeck
{
	public void Shuffle();

	public ICard GetCardByIndex(int index);

	public ICard GetCardByID(CardID id);

	public void AddCard(ICard card);

	public void RemoveCard(ICard card);
}
