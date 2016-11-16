using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviourSingleton<Player> {

	//	Lista de danos
	public List<Sprite> danos = new List<Sprite>();

	//	Lista de hearts
	public List<Image> hearts = new List<Image>();

	//	Imagens do coração
	public Image heart1;
	public Image heart2;
	public Image heart3;

	//	Contador de vidas
	//	Se chegar em 0 GAME OVER
	int i = 3;

	Collider2D col;

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

	Rigidbody2D rb;

	public Collider2D feet;

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

	void Update(){
		
		//	Pega os Itens quando o Player encosta e aperta a tecla Backspace
		if (col.gameObject.tag == "Item" && Input.GetKeyDown (KeyCode.Z)) {
			Debug.Log ("Pegou");
			inventario.addItem (col.gameObject.GetComponent<Itens>());
			Destroy (col.gameObject);
		} 
		//	Tomando dano
		if (col.name == "Damage") {
			if(vida >= 0){

				//0.2 sera o somatorio dos danos, dos itens danosos que estao na lista que o player tah encostando
				health -= 0.2f * Time.deltaTime;

				if (health <= 0f) {
					health = 1f;
					vida--;
				}


				lifeText.text = "Vida: " + vida--;	//	Altera o texto
				lifeTransform.sizeDelta = new Vector2 (vida*2f, lifeTransform.rect.height);
				//this.dano += col.GetComponent<Dano> ().dano;
				//this.dano -= col.GetComponent<Dano> ().dano;
			}

			//	GAME OVER
			if (vida == 0) {
				hearts.RemoveAt(0);
				//heart1.enabled = false;
				vida = 100;
				i--;
			}
		} 
		//	Restaurando life
		if (col.name == "Base") {
			if (vida <= 100) {
				lifeText.text = "Vida: " + vida++;	//	Altera o texto
				lifeTransform.sizeDelta = new Vector2 (vida * 2f, lifeTransform.rect.height);
			}
		}

	}


}
