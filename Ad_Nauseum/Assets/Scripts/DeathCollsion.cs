using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathCollsion : MonoBehaviour {

	// Timers for invincibility
	public float isecs;
	private float itimer;
	public float blinkTime;
	private float blinkClock;

	public GameObject deadPlayer;

	//Death Sound
	public AudioClip deathSound;
	public AudioClip shootSound;
	public AudioClip hitSound;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		itimer = 0;
		blinkClock = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (itimer > 0) {
			itimer -= Time.deltaTime;
			blinkClock += Time.deltaTime;
			if (blinkClock >= blinkTime) {
				GetComponent<SpriteRenderer> ().enabled = !(GetComponent<SpriteRenderer> ().enabled);
				blinkClock = 0;
			}
		} else {
			GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	//Called when the player collides with another trigger
	void OnTriggerStay2D(Collider2D other) {		
		//Checks the other object's tag: if it's the tag we're looking for, continue
		//NOTE: Application is deprecated. Find out how to use scenemanager
		if (itimer <= 0) {
			if (other.gameObject.CompareTag ("EvilTrigger")) {
				//GlobalVars.playerHealth -= 1;
				//itimer = isecs;
				//if (GlobalVars.playerHealth <= 0) {
				audioSource.PlayOneShot(hitSound, .8F);
				HealthMonitor.HP -= 35;
				itimer = isecs;
				Movement.stagger = true;
				Movement.staggerdir = -1;

				if (HealthMonitor.HP <= 0) {
					audioSource.PlayOneShot (deathSound, 1F);
					//HealthMonitor.HP = HealthMonitor.MaxHP;
					Instantiate (deadPlayer, this.gameObject.transform.position, Quaternion.identity);
					Destroy (this.gameObject);
					//SceneManager.LoadScene ("Demo_Level");
				}
			} else if (other.gameObject.CompareTag ("Enemy")) {
				// Need to add code to freeze enemy for a moment after the player hits it, to make damage less frustrating
				audioSource.PlayOneShot(hitSound, .8F);
				HealthMonitor.HP -= 20;
				itimer = isecs;
				Movement.stagger = true;
				Movement.staggerdir = Mathf.Sign (GetComponent<Rigidbody2D> ().position.x - other.attachedRigidbody.position.x);
				if (HealthMonitor.HP <= 0) {
					audioSource.PlayOneShot (deathSound, 1F);
					//HealthMonitor.HP = HealthMonitor.MaxHP;
					Instantiate (deadPlayer, this.gameObject.transform.position, Quaternion.identity);
					this.gameObject.SetActive (false);
					//SceneManager.LoadScene ("Demo_Level");
				}
			} else if (other.gameObject.CompareTag ("EnemyBullet")) {
				audioSource.PlayOneShot(hitSound, .6F);
				HealthMonitor.HP -= 15;
				itimer = isecs;
				Movement.stagger = true;
				Movement.staggerdir = Mathf.Sign (GetComponent<Rigidbody2D> ().position.x - other.attachedRigidbody.position.x);
				if (HealthMonitor.HP <= 0) {
					audioSource.PlayOneShot (deathSound, 1F);
					//HealthMonitor.HP = HealthMonitor.MaxHP;
					Instantiate (deadPlayer, this.gameObject.transform.position, Quaternion.identity);
					Destroy (this.gameObject);
					//SceneManager.LoadScene ("Demo_Level");
				}
				Destroy (other.gameObject);
			} else if (other.gameObject.CompareTag ("FallingRock")){
				audioSource.PlayOneShot(hitSound, .6F);
				HealthMonitor.HP -= 35;
				itimer = isecs;
				Movement.stagger = true;
				Movement.staggerdir = Mathf.Sign (GetComponent<Rigidbody2D> ().position.x - other.attachedRigidbody.position.x);
				if (HealthMonitor.HP <= 0) {
					audioSource.PlayOneShot (deathSound, 1F);
					//HealthMonitor.HP = HealthMonitor.MaxHP;
					Instantiate (deadPlayer, this.gameObject.transform.position, Quaternion.identity);
					Destroy (this.gameObject);
					//SceneManager.LoadScene ("Demo_Level");
				}
				Destroy (other.gameObject);
			}
		}

		if (other.gameObject.CompareTag ("SmallHealthPickup")) {
			HealthMonitor.HP += 20;
			audioSource.PlayOneShot (shootSound, .3F);
			if (HealthMonitor.HP >= HealthMonitor.MaxHP) {
				HealthMonitor.HP = HealthMonitor.MaxHP;
			}
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("BulletPowerUp")) {
			GlobalVars.bulletPowerUp = true;
			audioSource.PlayOneShot (shootSound, .4F);
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("EndLevel")) {
			GlobalVars.Reset ();
			HealthMonitor.HP = HealthMonitor.MaxHP;
			SceneManager.LoadScene ("EndScreen");
		}
	}
}
