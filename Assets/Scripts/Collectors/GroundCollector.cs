using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollector : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Ground" || target.tag == "Ground Decoration" || target.tag == "Background Decoration") {
			target.gameObject.SetActive(false);
		}
	}
}
