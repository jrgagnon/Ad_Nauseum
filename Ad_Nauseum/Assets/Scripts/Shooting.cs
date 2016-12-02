using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet;
	public GameObject chargedBullet;
	public float bulletAdX;
	public float bulletAdY;
	private Rigidbody2D self;
	private float shootPause;

	public GameObject powerBullet;
	public GameObject chargedPowerBullet;

    public float Max_Hold_Time = 2f;

    private float last_time = -1f;
    private float fire_threshold = .75f;

    private Animator animator;
	public AudioClip shootSound;

	private AudioSource audioSource;

	private Vector2 initialScale;

	// Use this for initialization
	void Start () {
		self = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
		shootPause = 0;
		initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		float amt;
		if (Input.GetButtonDown ("Fire2")) {

			audioSource.PlayOneShot (shootSound, .6F);

			if (GlobalVars.bulletPowerUp) {
				Instantiate (powerBullet, new Vector2 (self.position.x + bulletAdX, self.position.y + bulletAdY), Quaternion.identity);
			} else {
				Instantiate (bullet, new Vector2 (self.position.x + bulletAdX, self.position.y + bulletAdY), Quaternion.identity);
			}
			//animator.SetTrigger ("shooting");
			//animator.SetBool("shooting", true);
			shootPause = 1f;

			this.last_time = Time.time;

			/*if (Input.GetButtonDown ("Fire2")) {
				this.last_time = Time.time;
			} else if (Input.GetButtonUp ("Fire2") && this.last_time != -1 && this.last_time < Time.time) {
				if (this.last_time < Time.time + fire_threshold) {
					// Charged
					//@@@FireCodeHere
					amt = (Time.time - this.last_time);
					this.Fire (amt);
				} else {
					// Too quick, lesser
					//@@@FireCodeHere
					this.Fire (0f);
				}
				this.last_time = -1f;
			}*/
			// ----------------
			if (shootPause <= 0) {
				//animator.SetBool ("shooting", false);
			} else {
				shootPause -= 1 * Time.deltaTime;
			}
		} else if (Input.GetButtonUp ("Fire2") && this.last_time != -1 && this.last_time < Time.time) {
			if (this.last_time  + fire_threshold < Time.time) {
				// Charged
				//@@@FireCodeHere
				audioSource.PlayOneShot (shootSound, 1F);
				if (GlobalVars.bulletPowerUp) {
					Instantiate (chargedPowerBullet, new Vector2 (self.position.x + bulletAdX, self.position.y + bulletAdY), Quaternion.identity);
				} else {
					Instantiate (chargedBullet, new Vector2 (self.position.x + bulletAdX, self.position.y + bulletAdY), Quaternion.identity);
				}
				amt = (Time.time - this.last_time);
				//this.Fire (amt);
			} /*else {
				// Too quick, lesser
				//@@@FireCodeHere
				this.Fire (0f);
			}*/
			this.last_time = -1f;
		}

		if (this.last_time == -1f || Time.time - this.last_time < .75f) {
			transform.localScale = initialScale;
			if (Movement.turn) {
				transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			}
		} else {
			float x = Time.time - this.last_time - .75f;
			if (x >= Max_Hold_Time) {
				x = Max_Hold_Time;
			}
			x /= Max_Hold_Time;
			transform.localScale = initialScale * (1 + x/2);
			if (Movement.turn) {
				transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			}
		}
	}

    void Fire(float extra){
        
        extra = Mathf.Clamp(extra, 0f, Max_Hold_Time);
// @@@ Modify bullet here
        Instantiate(bullet, new Vector2(self.position.x + bulletAdX, self.position.y + bulletAdY), Quaternion.identity);

        //animator.SetTrigger ("shooting");
        //animator.SetBool("shooting", true);
        shootPause = 1f;
    }



}
