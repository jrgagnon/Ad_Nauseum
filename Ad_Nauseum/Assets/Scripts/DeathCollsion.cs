using UnityEngine;
using System.Collections;

public class DeathCollsion : MonoBehaviour {

	//For the player's own collider
	private BoxCollider2D self;

	// Use this for initialization
	void Start () {
		//Find the player's own collider
		self = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//Called when the player collides with another trigger
	void OnTriggerEnter2D(Collider2D other) {
		
		//Checks the other object's tag: if it's the tag we're looking for, continue
		if (other.gameObject.CompareTag("EvilTrigger")) {
			gameObject.SetActive (false);
		}
	}
}
