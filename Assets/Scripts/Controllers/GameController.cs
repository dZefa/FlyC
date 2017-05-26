using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private const string HIGH_SCORE = "High Score";
	private const string TUTORIAL = "Tutorial";

	void Awake(){
		MakeSingleton ();
		FirstPlayThrough ();
//		PlayerPrefs.SetInt ("Tutorial", 0);
	}

	void MakeSingleton(){
		if(instance != null){
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void FirstPlayThrough(){
		if (!PlayerPrefs.HasKey ("FirstPlay")) {
			PlayerPrefs.SetInt (HIGH_SCORE, 0);
			PlayerPrefs.SetInt (TUTORIAL, 0);
			PlayerPrefs.SetInt ("FirstPlay", 0);
		}
	}

	public void SetHighScore(int score){
		PlayerPrefs.SetInt (HIGH_SCORE, score);
	}

	public int GetHighSCore(){
		return PlayerPrefs.GetInt (HIGH_SCORE);
	}

	public void TutorialDone(){
		PlayerPrefs.SetInt (TUTORIAL, 1);
	}

	public int isTutorialDone(){
		return PlayerPrefs.GetInt (TUTORIAL);
	}
}
