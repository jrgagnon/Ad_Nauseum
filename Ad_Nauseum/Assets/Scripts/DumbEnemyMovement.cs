using UnityEngine;
using System.Collections;

public class DumbEnemyMovement : MonoBehaviour {

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

	public bool stationary;
	public bool boss;
	public float jumpTimer;
	private float lastTime;
	public float jumpSpeed;

	public GameObject rock;

	public AudioClip hitSound;
	private AudioSource audioSource;

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
		lastTime = Time.time;
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
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
		if (boss && GlobalVars.levelBossActive) {
			float x = self.transform.position.x;
			if (goingLeft && x > leftBoundExact) {
				self.transform.position = new Vector2 (self.transform.position.x - (speed * Time.deltaTime), self.transform.position.y);
			} else if (!goingLeft && x < rightBoundExact) {
				self.transform.position = new Vector2 (self.transform.position.x + (speed * Time.deltaTime), self.transform.position.y);
			} else {
				// If neither of the above are true, we've reached a bound and need to turn around.
				goingLeft = !goingLeft;
			}
			if (Time.time - lastTime >= jumpTimer) {
				this.gameObject.GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpSpeed));
				lastTime = Time.time;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Wall") && GlobalVars.levelBossActive && boss) {
			Instantiate (rock, new Vector2 (Random.Range(87.2f, 104.9f), 0), Quaternion.identity);
			Instantiate (rock, new Vector2 (Random.Range(87.2f, 104.9f), 0), Quaternion.identity);
			Instantiate (rock, new Vector2 (Random.Range(87.2f, 104.9f), 0), Quaternion.identity);
			Instantiate (rock, new Vector2 (Random.Range(87.2f, 104.9f), 0), Quaternion.identity);
			audioSource.PlayOneShot(hitSound, 1F);
		}
	}
}
