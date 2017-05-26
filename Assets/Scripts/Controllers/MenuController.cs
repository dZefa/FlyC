using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    [SerializeField]
    private GameObject adController;

    [SerializeField]
    private Button removeAd;

	public static MenuController instance;

	void Awake(){
		MakeInstance ();
	}

	void Start(){
        AdController.instance.ShowBanner();
	}

	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void PlayGame(){
		SceneFader.instance.FadeIn ("Gameplay");
	}

	public void OpenLeaderboardsScoreUI (){
		LeaderboardController.instance.OpenLeaderboardsScore ();
	}

	public void RateGame(){
		Application.OpenURL ("market://");
	}

	public void RemoveAd(){
//        AdController.instance.ShowRewardBasedVideo();

//        removeAd.gameObject.SetActive(false);
 //       adController.SetActive(false);
	}
}
