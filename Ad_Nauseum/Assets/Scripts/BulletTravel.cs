using UnityEngine;
using System.Collections;

public class BulletTravel : MonoBehaviour {

	private Rigidbody2D self;
	private bool direction;
	private GameObject player;
	private float speed;

	// Use this for initialization
	void Start () {
		speed = .1f;
		self = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player");
		if (player.transform.localScale.x == -1) {
			transform.localScale = new Vector2 (-1, 1);
			speed = speed * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		self.position = new Vector2(self.position.x + speed, self.position.y);
	}

	void OnBecameInvisible() {

		Debug.Log ("Hoopla");

		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collide) {

		/*if (collide.gameObject.CompareTag ("EvilTrigger")) {
			GameObject.Destroy (collide.gameObject);
			Debug.Log ("Boom");
		} else */
		if (collide.gameObject.CompareTag ("Enemy")) {
			GameObject.Destroy (collide.gameObject);
			GameObject.Destroy (self.gameObject);
		}

	}

}
