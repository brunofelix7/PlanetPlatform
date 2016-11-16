using UnityEngine;
using System.Collections;

public class PlanetCamera : MonoBehaviour {

	Vector3 currentPositionVelocity;
	float currentAngleVelocity;

	public float smooth;

	void LateUpdate () {
		SmoothPosition ();
		SmoothAngle ();
	}

	void SmoothPosition(){
		Vector3 currentPosition = this.transform.position;
		
		Vector3 wantedPosition = Player.Instance.transform.position;
		wantedPosition.z = currentPosition.z;
		
		Vector3 newPosition = Vector3.SmoothDamp (currentPosition, wantedPosition, ref currentPositionVelocity, smooth);
		this.transform.position = newPosition;
	}

	void SmoothAngle(){
		float currentAngle = this.transform.eulerAngles.z;

		float wantedAngle = Player.Instance.transform.eulerAngles.z;

		float newAngle = Mathf.SmoothDampAngle (currentAngle, wantedAngle, ref currentAngleVelocity, smooth);
		this.transform.rotation = Quaternion.Euler (0, 0, newAngle);
	}

}
