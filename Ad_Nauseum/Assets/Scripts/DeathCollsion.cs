using UnityEngine;
using System.Collections;

public class DeathCollsion : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	//Called when the player collides with another trigger
	void OnTriggerEnter2D(Collider2D other) {		
		//Checks the other object's tag: if it's the tag we're looking for, continue
		//NOTE: Application is deprecated. Find out how to use scenemanager
		if (other.gameObject.CompareTag ("EvilTrigger")) {
			Application.LoadLevel(Application.loadedLevel);
		} else if (other.gameObject.CompareTag ("Enemy")) {
			//Application.LoadLevel (Application.loadedLevel);
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
