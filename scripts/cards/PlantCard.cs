using Godot;
using System;

public partial class PlantCard: Resource, ICard
{
    [ExportGroup("Fields")]
    
    [Export] private string _name; 
    [Export] private Plant _plant; 
    [Export] private string _description;
    [Export] private CardID _id;

    public static readonly PlantCard PLACEHOLDER = new PlantCard("Placeholder","This is a placeholder.",new Plant("Placeholder Plant",0,(int)SeasonFlags.NONE,0,0,0),CardID.PL_GENERICPLANT);


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

