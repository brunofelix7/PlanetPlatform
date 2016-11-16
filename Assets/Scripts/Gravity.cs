using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour {

	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		float acc = Planet.Instance.gravityScale * Physics2D.gravity.magnitude;
		float force = rb.mass * acc;
		Vector2 dir = ((Vector2)Planet.Instance.transform.position - rb.position).normalized;
		rb.AddForce (dir * force);
	}
}
