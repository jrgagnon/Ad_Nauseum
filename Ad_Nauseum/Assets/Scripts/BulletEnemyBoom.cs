using UnityEngine;
using System.Collections;

public class BulletEnemyBoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter2D(Collider2D collide) {

		if (collide.gameObject.CompareTag ("EvilTrigger")) {

			Debug.Log ("Boom");

			Destroy (this.gameObject);
		} else if (collide.gameObject.CompareTag ("Enemy")) {

			Debug.Log ("Dead");

			Destroy (this.gameObject);
		} else {
			//Hits nothing
		}

	}
}
