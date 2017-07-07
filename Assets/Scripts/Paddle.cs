using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public static Paddle instance;
	public Rigidbody paddle;

	private float speed = 10;

	void Start () {
		instance = this;
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			MoveLeft ();
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			MoveRight ();
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			StopMovement ();
		}
	}

	void MoveLeft () {
		paddle.velocity = new Vector3 (-speed, 0, 0);
	}

	void MoveRight () {
		paddle.velocity = new Vector3 (speed, 0, 0);
	}

	void StopMovement () {
		paddle.velocity = Vector3.zero;
	}

	public void ScalePaddle (float scale = 0) {
		transform.localScale += new Vector3 (scale, 0, 0);
	}

}