using UnityEngine;
using System.Collections;

public class KeepPlanetRotation : MonoBehaviour {

	public enum Type{
		Start, Transform, Rigidbody
	}

	public Type type;

	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		if (type == Type.Start) {
			this.transform.rotation = Quaternion.Euler (0, 0, Planet.Instance.CalcWantedAngle(this.transform.position));
		}
	}

	void Update () {
		if (type == Type.Transform) {
			this.transform.rotation = Quaternion.Euler (0, 0, Planet.Instance.CalcWantedAngle(this.transform.position));
		}
	}

	void FixedUpdate(){
		if (type == Type.Rigidbody) {
			rb.MoveRotation (Planet.Instance.CalcWantedAngle(rb.position));
		}
	}

}
