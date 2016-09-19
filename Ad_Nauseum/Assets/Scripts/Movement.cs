﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody2D body;
	public float speed;
	public float jumpSpeed;

	private bool airborne;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		airborne = false;
	}
	
	// Update is called once per frame
	void Update () {

		float movement = 0;
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			movement += speed * Time.deltaTime;

		}

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			movement += -speed * Time.deltaTime;
		}


	
		body.position = new Vector2(body.position.x + movement, body.position.y);

		if (airborne == true) {
			if (body.velocity.y == 0) {
				airborne = false;
			}
		}

		if (Input.GetButtonDown ("Fire1") && body.velocity.y == 0) {
			body.AddForce (new Vector2 (0, jumpSpeed));
			airborne = true;
		}

	}
}
