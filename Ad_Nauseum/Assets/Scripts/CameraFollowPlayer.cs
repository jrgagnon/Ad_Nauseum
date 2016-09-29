using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	Rigidbody2D player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (player.position.x, transform.position.y, transform.position.z);
	}
}
