using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollector : MonoBehaviour {

	private GameObject[] wallHolders;

	private float lastWallX;
	private float distance = 3f;
	private float wallMin = -0.9f;
	private float wallMax = 2.5f;

	void Awake () {
		wallHolders = GameObject.FindGameObjectsWithTag ("Wall Holder");

		for (int i = 0; i < wallHolders.Length; i++) {
			Vector3 temp = wallHolders [i].transform.position;
			temp.x = Random.Range (wallMin, wallMax);
			wallHolders [i].transform.position = temp;
		}

		lastWallX = wallHolders [0].transform.position.y;

		for (int i = 1; i < wallHolders.Length; i++) {
			if (lastWallX < wallHolders [i].transform.position.y) {
				lastWallX = wallHolders [i].transform.position.y;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D target){
		if(target.tag == "Wall Holder"){
			Vector3 temp = target.transform.position;

			temp.y = lastWallX + distance;
			temp.x = Random.Range (wallMin, wallMax);

			target.transform.position = temp;

			lastWallX = temp.y;
		}
	}
}
