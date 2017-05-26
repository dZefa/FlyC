using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {
	public static GameplayController instance;

	[SerializeField]
	private Text gameScoreText, gameScoreLabelText, scoreText, bestScoreText, pausedText;

	[SerializeField]
	private Button backButton, instructionsButton, pauseButton, menuButton;

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private Sprite[] medals;

	[SerializeField]
	private Image medalImage, gameoverImage, newBestScore;

    private float adNumber;

	void Awake(){
		MakeInstance ();
		Invoke ("PlayTutorial", 0.35f);
	}

	void MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void PauseGame(){
		if (PlayerScript.instance != null) {
			if (PlayerScript.instance.isAlive) {
				pausePanel.SetActive (true);
				pauseButton.gameObject.SetActive (false);
				gameoverImage.gameObject.SetActive (false);
				gameScoreText.gameObject.SetActive (false);
				gameScoreLabelText.gameObject.SetActive (false);
				newBestScore.gameObject.SetActive (false);
				medalImage.gameObject.SetActive (false);
				menuButton.gameObject.SetActive (true);

				scoreText.text = "" + PlayerScript.instance.score;
				bestScoreText.text = "" + GameController.instance.GetHighSCore ();

				Time.timeScale = 0f;
			}
		}
	}

	public void GoToMenuButton(){
        Time.timeScale = 1f;
        SceneFader.instance.FadeIn("MainMenu");

        adNumber = Random.Range(0f, 100f);

        if(adNumber > 10 && adNumber < 41)
        {
            AdController.instance.ShowInterstitial();
        } else if (adNumber < 11)
        {
            AdController.instance.ShowRewardBasedVideo();
        }
    }

	public void ResumeGame(){
		pausePanel.SetActive (false);
		pauseButton.gameObject.SetActive (true);
		gameScoreText.gameObject.SetActive (true);
		gameScoreLabelText.gameObject.SetActive (true);

		Time.timeScale = 1f;
	}

	public void PlayGame(){
		gameScoreText.gameObject.SetActive (true);
		gameScoreLabelText.gameObject.SetActive (true);
		pauseButton.gameObject.SetActive (true);

		Time.timeScale = 1f;
	}

	private void PlayTutorial(){
		Time.timeScale = 0f;

		if (GameController.instance.isTutorialDone () != 1) {
			instructionsButton.gameObject.SetActive (true);
		} else {
			PlayGame ();
		}
	}

	public void Tutorial() {
		instructionsButton.gameObject.SetActive (false);
		GameController.instance.TutorialDone ();
		PlayGame ();
	}

	public void SetScore(int score){
		gameScoreText.text = "" + score;
	}

	public void PlayerDiedShowScore(int score){
		pausePanel.gameObject.SetActive (true);
		pauseButton.gameObject.SetActive (false);
		gameScoreLabelText.gameObject.SetActive (false);
		gameScoreText.gameObject.SetActive (false);
		gameoverImage.gameObject.SetActive (true);
		pausedText.gameObject.SetActive (false);
		menuButton.gameObject.SetActive (false);

		Time.timeScale = 0f;

		scoreText.text = "" + score;

		if (score > GameController.instance.GetHighSCore ()) {
			GameController.instance.SetHighScore (score);
			newBestScore.gameObject.SetActive (true);
		}

		bestScoreText.text = "" + GameController.instance.GetHighSCore ();

		if (score < 20) {
			medalImage.gameObject.SetActive (false);
		} else if (score > 20 && score < 40) {
			medalImage.sprite = medals [0];
			medalImage.gameObject.SetActive (true);
		} else if (score > 40 && score < 60) {
			medalImage.sprite = medals [1];
			medalImage.gameObject.SetActive (true);
		} else {
			medalImage.sprite = medals [2];
			medalImage.gameObject.SetActive (true);
		}

		backButton.onClick.RemoveAllListeners ();
		backButton.onClick.AddListener (() => GoToMenuButton ());

        LeaderboardController.instance.ReportScore(GameController.instance.GetHighSCore());
	}
}
