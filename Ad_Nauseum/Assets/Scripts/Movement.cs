﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody2D body;
	public float speed;
	public float jumpSpeed;
	public static bool turn;

	public static bool stagger = false;
	public static float staggerdir = 1;
	// staggerTime = total time staggered, staggerClock is an internal timer
	public float staggerTime;
	private float staggerClock;
	public float staggerSpeed;

	public bool airborne;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		airborne = false;
		staggerClock = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float movement = 0;                                                                                                                        

		// If hit, player will stagger backwards away from enemy
		if (stagger) {
			movement += ((staggerSpeed) * Time.fixedDeltaTime) * staggerdir;
			staggerClock += Time.fixedDeltaTime;
			if (staggerClock >= staggerTime) {
				stagger = false;
				staggerClock = 0;
			}
		} else {
			if (Input.GetAxisRaw ("Horizontal") > 0) {
				movement += speed * Time.fixedDeltaTime;
				//transform.localScale = new Vector2 (1, 1);
				turn = false;
			}

			if (Input.GetAxisRaw ("Horizontal") < 0) {
				movement += -speed * Time.fixedDeltaTime;
				//transform.localScale = new Vector2 (-1, 1);
				turn = true;
			}
		}
	
		body.position += new Vector2(/*body.position.x + */movement, 0 /*body.position.y*/);


		if (airborne == true) {
			if (body.velocity.y == 0) {
				airborne = false;
			}
		}

		if ((Input.GetButtonDown ("Fire1") || Input.GetButton ("Fire1")) && body.velocity.y == 0) {
			body.AddForce (new Vector2 (0, jumpSpeed));
			airborne = true;
		}

	}

	//void OnCollisionEnter2D(Collision2D other){
		//if (other.gameObject.CompareTag ("Wall") || other.gameObject.CompareTag ("BrokenWall") || other.gameObject.CompareTag ("EvilTrigger")) {
		//	airborne = false;
		//}
	//}
}
