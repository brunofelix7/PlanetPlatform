using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	Player player;
	public Animator playerAnimator;
	public bool runBack;

	void Start () {
		player = GetComponent<Player> ();
	}

	void Update () {
		float h = Input.GetAxis ("Horizontal");
		player.input = h;
		if(h < 0f) {
			runBack = true;
		}if(h > 0f) {
			runBack = false;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			player.jump = true;
		}

		playerAnimator.SetBool ("runBack", runBack);
	}
}
