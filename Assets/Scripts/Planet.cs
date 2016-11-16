using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviourSingleton<Planet> {

	public float gravityScale = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float CalcWantedAngle(Vector2 objectPos){
		
		Vector2 planetPos = this.transform.position;

		Vector2 up = (objectPos - planetPos).normalized;
		Vector2 right = (Vector2)(Quaternion.Euler (0, 0, -90) * up);

		float wantedAngle = Mathf.Atan2 (right.y, right.x) * Mathf.Rad2Deg;

		return wantedAngle;
	}

}
