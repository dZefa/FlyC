using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerScript : MonoBehaviour{

	public static PlayerScript instance;

	[SerializeField]
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private Animator anim;

	public int score;

	private float speed = 2f;

	private float jumpSpeed = 5f;

	private bool didFlap, flapLeft, flapRight;

	public bool isAlive;

	private Button flapButton;

	[SerializeField]
	private AudioSource audioBird;

	[SerializeField]
	private AudioClip flapClip, pointClip, diedClip, hitClip;

	void Awake(){
		if (instance == null) {
			instance = this;
		}

		isAlive = true;
	}

	void Start () {
	}

	void FixedUpdate () {
		if (flapLeft) {
			FlapLeft ();
		}

		if (flapRight) {
			FlapRight ();
		}
	}

	public void FlapTheBird(){
		didFlap = true;
	}

	public void SetFlapLeft(bool moveLeft){
		this.flapLeft = moveLeft;
		this.flapRight = !moveLeft;
	}

	public void StopMoving(){
		flapLeft = flapRight = false;
	}

	void FlapLeft() {
		if (isAlive && didFlap) {
			didFlap = false;

			Vector3 temp = transform.localScale;
			temp.x = -2f;
			temp.y = 2f;
			transform.localScale = temp;

			myRigidBody.velocity = new Vector2 (-speed, jumpSpeed);

			audioBird.PlayOneShot (flapClip);
			anim.SetTrigger ("Flap");
		}
	}

	void FlapRight() {
		if (isAlive && didFlap) {
			didFlap = false;

			Vector3 temp = transform.localScale;
			temp.x = 2f;
			temp.y = 2f;
			transform.localScale = temp;

			myRigidBody.velocity = new Vector2 (speed, jumpSpeed);

			audioBird.PlayOneShot (flapClip);
			anim.SetTrigger ("Flap");
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Wall Holder") {
			score++;
			GameplayController.instance.SetScore (score);
			audioBird.PlayOneShot (pointClip);
		}

		if (target.tag == "BirdCollector") {
			if (isAlive) {
				isAlive = false;
				anim.SetTrigger ("Death");
				audioBird.PlayOneShot (diedClip);
				GameplayController.instance.PlayerDiedShowScore (score);
			}
		}
	}
}
