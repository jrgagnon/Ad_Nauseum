using UnityEngine;
using System.Collections;

public class BulletTravel : MonoBehaviour {

	private Rigidbody2D self;

	// Use this for initialization
	void Start () {
		self = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		self.position = new Vector2(self.position.x + .64f, self.position.y);
	}

	void OnBecameInvisible() {

		Debug.Log ("Hoopla");

		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collide) {

		if (collide.gameObject.CompareTag("EvilTrigger")) {
			
			Debug.Log ("Boom");
		}

	}

}
