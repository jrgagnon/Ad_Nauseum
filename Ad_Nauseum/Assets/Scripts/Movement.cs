using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody2D body;
	public float speed;
	public float jumpSpeed;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		float movement = 0;
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			movement += speed;

		}

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			movement += -speed;
		}


	
		body.position = new Vector2(body.position.x + movement, body.position.y);

		if (Input.GetButtonDown ("Fire1")) {
			body.AddForce (new Vector2 (0, jumpSpeed));
		}

	}
}
