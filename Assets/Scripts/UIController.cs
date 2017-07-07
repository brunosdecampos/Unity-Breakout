using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	int score = 0;
	public Text scoreText;

	public void IncrementScore () {

		score++;
		scoreText.text = "Score: " + score;

	}

}
