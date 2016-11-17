
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviourSingleton<Player> {

	//	Lista de danos
	public List<Image> danos = new List<Image>();

	List<Itens> itemsEncostando = new List<Itens>();

	//	Lista de hearts
	public Image[] hearts;

	//	Contador de vidas
	//	Se chegar em 0 GAME OVER
	public int coracoes = 3;

	public Collider2D feet;
	Rigidbody2D rb;

	float health = 1f;

	//	Barra de Vida
	public RectTransform lifeTransform;
	public Text lifeText;
	public int vida = 100;
	public float barraVida = 200f;


	//	Iventario
	public RectTransform slot;

	public Inventario inventario;


	public float speed;
	public float jumpSpeed;

	public float input;
	public bool jump;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	bool CanJump{
		get{
			return feet.IsTouchingLayers ();
		}
	}

	void FixedUpdate () {

		Vector2 planetPos = Planet.Instance.transform.position;
		Vector2 playerPos = rb.position;

		Vector2 up = (playerPos - planetPos).normalized;
		Vector2 right = (Vector2)(Quaternion.Euler (0, 0, -90) * up);

		float vUp = Vector2.Dot (rb.velocity, up);
		float vRight = Vector2.Dot (rb.velocity, right);

		if (jump && CanJump) {
			vUp = jumpSpeed;
		}
		jump = false;
		vRight = input * speed;

		rb.velocity = up * vUp + right * vRight;
			
		//life -= dano * Time.deltaTime;

	}

	public void Interagir(Itens item1, Itens item2){
		if ((int)item1.type > (int)item2.type) {
			Interagir (item2, item1);
		} else {
			if (item1.type == Itens.ItemType.Agua && item2.type == Itens.ItemType.Cristal) {
				item2.Destruir ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("Item")) {
			itemsEncostando.Add (col.GetComponent<Itens> ());
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.CompareTag ("Item")) {
			itemsEncostando.Remove(col.GetComponent<Itens> ());
		}
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.Z)) {
			if (itemsEncostando.Count > 0) {
				//faz alguma coisa com itemsEncostando[0]
				//Destroy(itemsEncostando[0].gameObject);
				//itemsEncostando.RemoveAt(0);
			}
		}

		//	Pega os Itens quando o Player encosta e aperta a tecla Backspace
		if (feet.gameObject.tag == "Item" && Input.GetKeyDown (KeyCode.Z)) {
			Debug.Log ("Pegou");
			inventario.addItem (feet.gameObject.GetComponent<Itens>());
			Destroy (feet.gameObject);
		} 
		//	Tomando dano
		if (feet.name == "Damage") {
			if(vida >= 0){

				//0.2 sera o somatorio dos danos, dos itens danosos que estao na lista que o player tah encostando
				health -= 0.2f * Time.deltaTime;

				if (health <= 0f) {
					health = 1f;
					vida--;
				}

				//this.dano += col.GetComponent<Dano> ().dano;
				//this.dano -= col.GetComponent<Dano> ().dano;
			}

			//	GAME OVER
			if (vida == 0) {
				//game over
			}
		} 
		//	Restaurando life
		/*
		if (col.name == "Base") {
			if (vida <= 100) {
				vida++;
			}
		}
		*/

		lifeText.text = "Vida: " + vida;	//	Altera o texto
		lifeTransform.sizeDelta = new Vector2 (vida*2f, lifeTransform.rect.height);
		for (int i = 0; i < hearts.Length; i++) {
			hearts [i].gameObject.SetActive (vida > i);
		}
		
	}

}
