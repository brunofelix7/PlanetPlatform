using UnityEngine;
using System.Collections;

public class Itens : MonoBehaviour {

	public enum ItemType { 
		Maca = 0, Tijolo = 1, Agua = 2, Rocha = 3, Madeira = 4, Pedra = 5, Cristal = 6, Terra = 7
	}

	public ItemType type;
	public string nome;
	public Sprite prefabs;
	public int x;

	public Itens(string nome, ItemType _type){
		this.nome = nome;
		this.type = _type;
		this.prefabs = Resources.Load<Sprite> ("Prefabs/ " + nome);
	}

	public Itens(){

	}


	public void Ligar(){

	}
	public void Desligar(){
		
	}
	public void Destruir(){
		
	}

}
