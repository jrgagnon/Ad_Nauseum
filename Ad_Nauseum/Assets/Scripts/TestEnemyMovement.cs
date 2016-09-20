using UnityEngine;
using System.Collections;

public class TestEnemyMovement : MonoBehaviour {

	Rigidbody2D body;
	Rigidbody2D player;
	public float speed;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player").GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		float xmod = 0;

		if (player.position.x < body.position.x) {
			xmod = -1;
		} else {
			xmod = 1;
		}
			
		body.position = new Vector2 (body.position.x + ((speed * xmod) * Time.deltaTime), body.position.y);

	}
}
