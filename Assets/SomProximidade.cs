using UnityEngine;
using System.Collections;

public class SomProximidade : MonoBehaviour {

	public float limite = 5;

	void Update () {
		float dist = Vector3.Distance (this.transform.position, Player.Instance.transform.position);
		dist = dist / limite;
		dist = Mathf.Clamp01 (dist);
		float volume = 1f - dist;
		GetComponent<AudioSource> ().volume = volume;
	}
}
 