﻿using UnityEngine;
using System.Collections;

public class EnemyThatShoots : MonoBehaviour {

	public float speed;
	public float leftBound;
	public float rightBound;
	private float leftBoundExact;
	private float rightBoundExact;
	// Toggle whether the bounds are relative or exact
	public bool relative;
	// Used to determine which direction the enemy is heading
	private bool goingLeft;
	// Used cuz I want to pull my goddamn hair out typing this
	private Rigidbody2D self;

	// Used to determine how often this enemy shoots
	public float shootInterval;
	// Used to keep track of time or something gdi
	private float shootTimer;
	// The bullet to shoot
	public GameObject bullet;

	public bool stationary;

	// Use this for initialization
	void Start () {
		if (!relative) {
			leftBoundExact = leftBound;
			rightBoundExact = rightBound;
		} else {
			leftBoundExact = GetComponent<Rigidbody2D> ().transform.position.x + leftBound;
			rightBoundExact = GetComponent<Rigidbody2D> ().transform.position.x + rightBound;
		}
		self = GetComponent<Rigidbody2D> ();
		goingLeft = true;
		shootTimer = 0f;
	}

	// Update is called once per frame
	void Update () {
		// Update the timer and see if we've reached an interval
		if (GameObject.Find ("Player")) {
			shootTimer += Time.deltaTime;
			if (shootTimer >= shootInterval && GetComponent<Renderer> ().isVisible) {
				shootTimer = 0f;
				// Shoot a bullet toward the player
				Instantiate (bullet, new Vector2 (self.position.x, self.position.y), Quaternion.identity);
			}
		}
		if (!stationary) {
			float x = self.transform.position.x;
			if (goingLeft && x > leftBoundExact) {
				self.transform.position = new Vector2 (self.transform.position.x - (speed * Time.deltaTime), self.transform.position.y);
			} else if (!goingLeft && x < rightBoundExact) {
				self.transform.position = new Vector2 (self.transform.position.x + (speed * Time.deltaTime), self.transform.position.y);
			} else {
				// If neither of the above are true, we've reached a bound and need to turn around.
				goingLeft = !goingLeft;
			}
		}


	}
}
