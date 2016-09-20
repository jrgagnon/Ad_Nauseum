using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet;
	public float bulletAd;
	private Rigidbody2D self;

	// Use this for initialization
	void Start () {
		self = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			Instantiate (bullet, new Vector2(self.position.x + bulletAd, self.position.y), Quaternion.identity);
		}
			

	}


}
