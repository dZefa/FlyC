using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private float speed = 0.5f;
	private float acceleration = 0.03f;
	private float maxSpeed = 10f;

	[HideInInspector]
	public bool moveCamera;

	void Start () {
		moveCamera = true;
	}

	void Update () {
		if (moveCamera) {
			MoveCamera ();
		}
	}

	void MoveCamera(){

		Vector3 temp = transform.position;

		float oldY = temp.y;
		float newY = temp.y + (speed * Time.deltaTime);

		temp.y = Mathf.Clamp (temp.y, newY, oldY);

		transform.position = temp;

		speed += acceleration * Time.deltaTime;

		if (speed > maxSpeed) {
			speed = maxSpeed;
		}
	}
}
