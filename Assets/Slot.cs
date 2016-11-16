using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

	public Image image;

	public Itens.ItemType type;

	public void ConfigIndex(Inventario inventario, int index){
		GetComponent<Button> ().onClick.AddListener (() => {
			inventario.ApertouBotao(index);
		});
	}

	public void Config (Itens.ItemType type, Sprite sprite) {
		this.type = type;
		this.image.sprite = sprite;
	}

}
