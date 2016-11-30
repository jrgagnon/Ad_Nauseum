using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullet;
	public float bulletAdX;
	public float bulletAdY;
	private Rigidbody2D self;
	private float shootPause;

    public float Max_Hold_Time = 10.5f;

    private float last_time = -1f;
    private float fire_threshold = 0.045f;

    private Animator animator;
	public AudioClip shootSound;

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
		
		float amt;
		if (Input.GetButtonDown ("Fire2")) {

			audioSource.PlayOneShot (shootSound, 1F);

			Instantiate (bullet, new Vector2 (self.position.x + bulletAdX, self.position.y + bulletAdY), Quaternion.identity);

			//animator.SetTrigger ("shooting");
			//animator.SetBool("shooting", true);
			shootPause = 1f;

			if (Input.GetButtonDown ("Fire2")) {
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
			}
			// ----------------
			if (shootPause <= 0) {
				//animator.SetBool ("shooting", false);
			} else {
				shootPause -= 1 * Time.deltaTime;
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
