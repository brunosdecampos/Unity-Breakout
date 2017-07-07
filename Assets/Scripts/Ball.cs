using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {
	
	private Vector3 direction = new Vector3 (1, -1, 0);
	private float speed = 1f;
	private double x, y, lastX, lastY, currX, currY;
	private int count = 0;

	void Start () {
		direction.Normalize ();
		// Paddle.instance.ScalePaddle (10.25f);
	}

	void Update () {
		count++;

		this.transform.position += direction * speed * Time.deltaTime;

		x = Mathf.Round(transform.position.x * 100f) / 100f;
		y = Mathf.Round (transform.position.y * 100f) / 100f;

		x = System.Math.Round (x, 1);
		y = System.Math.Round (y, 1);

		if (count % 2 == 0) {
			currX = x;
			currY = y;
		} else {
			lastX = x;
			lastY = y;
		}

		if (count >= 2 && lastX == currX && lastY == currY) {
			transform.position += direction * 5.0f * speed * Time.deltaTime;
		}
	}

	void OnCollisionEnter (Collision collision) {
		Vector3 normalVector = collision.contacts [0].normal;

		direction = Vector3.Reflect (direction, normalVector);
		direction.Normalize ();

		if (collision.gameObject.tag == "Brick") {
			Destroy (collision.gameObject);
			GameController.instance.IncrementScore ();
		}

		if (collision.gameObject.tag == "Bottom") {
			GameController.instance.IncrementAttempts ();
		}
	}

}