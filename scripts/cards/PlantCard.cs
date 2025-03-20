using Godot;
using System;

public partial class PlantCard: ICard
{
    private string _name; 
    private Plant _plant; 
    private string _description;

    private CardID _id;


    public PlantCard(string name, string description, Plant plant, CardID id){
        
        this._plant = plant;
        this._name = name;
        this._description = description;
        this._id = id;
    }


	public Plant GetPlant(){
        return _plant;
    }
	public string GetName(){
        return _name;
    }
	public string GetDescription(){
        return _description;
    }
    public CardID GetID(){
        return _id;
    }

    public void SetName(string name){
        this._name = name;
    }
    public void SetDescription(string description){
        this._description = description;
    }
    public void SetPlant(Plant p){
        this._plant = p;
    }

    public void SetCardID(CardID id){
        this._id = id;
    }
}

