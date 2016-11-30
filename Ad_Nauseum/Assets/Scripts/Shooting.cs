using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet;
	public float bulletAdX;
	public float bulletAdY;
	private Rigidbody2D self;
	private float shootPause;

	public AudioClip shootSound;

	private Animator animator;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		self = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
		shootPause = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {

			audioSource.PlayOneShot (shootSound, 1F);

			Instantiate (bullet, new Vector2(self.position.x + bulletAdX, self.position.y + bulletAdY), Quaternion.identity);

			//animator.SetTrigger ("shooting");
			//animator.SetBool("shooting", true);
			shootPause = 1f;

		}
		if (shootPause <= 0) {
			//animator.SetBool ("shooting", false);
		} else {
			shootPause -= 1 * Time.deltaTime;
		}

			

	}



}
