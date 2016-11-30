using UnityEngine;
using System.Collections;

public class DeathCollsion : MonoBehaviour {

	public AudioClip deathSound;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//Called when the player collides with another trigger
	void OnTriggerEnter2D(Collider2D other) {		
		//Checks the other object's tag: if it's the tag we're looking for, continue
		//NOTE: Application is deprecated. Find out how to use scenemanager

		if (other.gameObject.CompareTag ("EvilTrigger")) {
			audioSource.PlayOneShot (deathSound, 1F);
			Application.LoadLevel(Application.loadedLevel);
		} else if (other.gameObject.CompareTag ("Enemy")) {
			//Application.LoadLevel (Application.loadedLevel);
			audioSource.PlayOneShot (deathSound, 1F);
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
