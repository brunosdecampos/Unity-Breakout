using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public Text score;
	public Text attempts;
	public Text powerUps;

	private static int scoreCounter = 0;
	private static int attemptsCounter = 1;
	private static int powerUpsCounter = 0;
	private static int consecutiveBreaks = 0;
	private static int currentLevel = 1;
	private int totalBlocks;

	void Start () {
		instance = this;
		consecutiveBreaks = 0;

		ResetTextValues ();

		totalBlocks = currentLevel * 20;
	}

	void ResetValues () {
		scoreCounter = 0;
		attemptsCounter = 1;
		powerUpsCounter = 0;
	}

	void ResetTextValues () {
		score.text = scoreCounter.ToString ("000");
		attempts.text = attemptsCounter.ToString ();
		powerUps.text = powerUpsCounter.ToString ("000");
	}

	public void IncrementScore () {
		scoreCounter++;
		consecutiveBreaks++;
		score.text = scoreCounter.ToString ("000");

		if (consecutiveBreaks == 3) {
			Paddle.instance.ScalePaddle (0.1f);
			powerUpsCounter++;

			powerUps.text = powerUpsCounter.ToString ("000");
			consecutiveBreaks = 0;
		}

		if (scoreCounter == totalBlocks) {
			ResetValues ();
			NextLevel ();
			ResetTextValues ();
		}
	}

	public void IncrementAttempts () {
		attemptsCounter++;

		if (attemptsCounter == 6) {
			ResetValues ();
		}

		attempts.text = attemptsCounter.ToString ();
		GameOver ();
	}

	public void GameOver () {
		powerUpsCounter = 0;
		powerUps.text = powerUpsCounter.ToString ("000");
		SceneManager.LoadScene ("Level" + currentLevel);
	}

	public void NextLevel () {
		if (currentLevel == 3) {
			currentLevel = 1;
		} else {
			currentLevel++;
		}

		ResetValues ();
		ResetTextValues ();

		Paddle.instance.ScalePaddle ();
		SceneManager.LoadScene ("Level" + currentLevel);
	}

}