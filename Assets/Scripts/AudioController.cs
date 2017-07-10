using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioClip clip;
	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "Ball") {
			StartCoroutine(PlayBrickSoundCoroutine ());
		}
	}

	IEnumerator PlayBrickSoundCoroutine () {
		source.PlayOneShot (clip);
		yield return null;

		DestroyBrick ();
	}

	void DestroyBrick () {
		if (this.gameObject.tag == "Brick") {
			Destroy (this.gameObject);
		}
	}
}
