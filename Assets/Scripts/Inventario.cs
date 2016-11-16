using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventario : MonoBehaviour {



	int count = 0;
	public Text textInventario;
	public GameObject prefab;

	public Button[] button;

	[System.Serializable]
	public class IItem{
		public Itens.ItemType type;
		public Sprite sprite;
	}
	
	public List<IItem> itemsAtuais;


	public void addItem(Itens item){
		itemsAtuais.Add(new IItem(){
			type = item.type,
			sprite = item.prefabs
		});

		UpdateVisual();
	}

	private void addItemSlot(){
	
	}

	void UpdateVisual(){
		for (int i = 0; i < button.Length; i++) {
			button [i].gameObject.SetActive (false);
		}
		for (int i = 0; i < itemsAtuais.Count; i++) {
			button [i].gameObject.SetActive (true);
			button [i].GetComponent<Slot> ().Config (itemsAtuais [i].type, itemsAtuais [i].sprite);
		}
	}

	public void ApertouBotao(int i){
		print ("apertou " + i);
		if(i < itemsAtuais.Count){
			
			IItem iitem = itemsAtuais[i];
			//(i.type)
			itemsAtuais.RemoveAt(i);
			//fazer alguma coisa com o item que usou
			UpdateVisual();
		}
		
	}

	public void clicouNoBotao(){
		textInventario.text = "Usou item: " + ++count;
		Instantiate(prefab, new Vector3(13.14f, 15.77f, 0), Quaternion.identity);
	}

	void Start(){

		for (int i = 0; i < button.Length; i++) {
			button [i].GetComponent<Slot> ().ConfigIndex (this, i);
		}

		UpdateVisual ();
	}

}
