using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Itens> item = new List<Itens>();

	void Start () {
	
		item.Add (new Itens("ItemMaca", Itens.ItemType.Maca));
		item.Add (new Itens("ItemTijolo", Itens.ItemType.Tijolo));
		item.Add (new Itens("ItemAgua", Itens.ItemType.Agua));
		item.Add (new Itens("ItemRocha", Itens.ItemType.Rocha));
		item.Add (new Itens("ItemMadeira", Itens.ItemType.Madeira));
		item.Add (new Itens("ItemPedra", Itens.ItemType.Pedra));
		item.Add (new Itens("ItemCristal", Itens.ItemType.Cristal));
		item.Add (new Itens("ItemTerra", Itens.ItemType.Terra));

	}

}
