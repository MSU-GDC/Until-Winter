using Godot;
using System;

public partial class Card: ICard
{
    private string _name; 
    private Plant _plant; 
    private string _description;


    public Card(string name, string description, Plant plant){
        
        this._plant = plant;
        this._name = name;
        this._description = description;
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
    public void SetName(string name){
        this._name = name;
    }
    public void SetDescription(string description){
        this._description = description;
    }
    public void SetPlant(Plant p){
        this._plant = p;
    }
}

