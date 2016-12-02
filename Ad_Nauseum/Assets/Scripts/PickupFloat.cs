using UnityEngine;
using System.Collections;

public class PickupFloat : MonoBehaviour {

	private Rigidbody2D self;

	private float speed;
	private float dist;
	private float upperBound;
	private float lowerBound;
	private float innerUp;
	private float innerLow;
	private bool dir;

	// Use this for initialization
	void Start () {
		self = GetComponent<Rigidbody2D> ();
		dist = .3f;
		speed = .01f;
		upperBound = self.transform.position.y + dist;
		lowerBound = self.transform.position.y - dist;
		innerUp = self.transform.position.y + dist / 2;
		innerLow = self.transform.position.y - dist / 2;
		dir = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (dir) {
			float y = Mathf.Lerp (this.transform.position.y, upperBound, speed);
			this.transform.position = new Vector2 (this.transform.position.x, y);
			if (this.transform.position.y >= innerUp) {
				dir = !dir;
			}
		} else {
			float y = Mathf.Lerp (this.transform.position.y, lowerBound, speed);
			this.transform.position = new Vector2 (this.transform.position.x, y);
			if (this.transform.position.y <= innerLow) {
				dir = !dir;
			}
		}
	}
}
