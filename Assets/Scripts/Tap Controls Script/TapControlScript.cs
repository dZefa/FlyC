using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapControlScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	private PlayerScript player;

	public void OnPointerUp(PointerEventData data){
		player.StopMoving ();
	}

	public void OnPointerDown (PointerEventData data) {
		if (gameObject.name == "Left Tap Button") {
			player.SetFlapLeft (true);
		} else {
			player.SetFlapLeft (false);
		}
	}
		
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Bird").GetComponent<PlayerScript> ();
	}
}
