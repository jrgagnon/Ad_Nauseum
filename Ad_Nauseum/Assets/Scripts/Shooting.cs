using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet;
	public float bulletAdX;
	public float bulletAdY;
	private Rigidbody2D self;

	// Use this for initialization
	void Start () {
		self = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			Instantiate (bullet, new Vector2(self.position.x + bulletAdX, self.position.y + bulletAdY), Quaternion.identity);
			GetComponent<Animator>().SetBool("shooting", true);
		}
			

	}


}
