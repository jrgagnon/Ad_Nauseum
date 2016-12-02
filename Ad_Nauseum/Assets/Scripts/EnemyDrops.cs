using UnityEngine;
using System.Collections;

public class EnemyDrops : MonoBehaviour {

	/* Note: As of right now, the drops all fall on the same chart.
	 * This means that only one thing can drop at a time. This also
	 * means that the sum of all of the drop chances must be less than
	 * or equal to 1. If they equal 1, a random item will always drop. 
	*/

	// The rates of all of the drops.
	// Whenever you add a new drop, make sure you update the start function
	public float enemyHealth;
	public float smallHealthRate;
	public float trophyRate;
	public GameObject smallHealth;
	public GameObject trophy;

	public AudioClip hitSound;
	private AudioSource audioSource;

	/* This program will use ints corresponding to the following list.
	 * If you add a new drop, make sure to update this list. I'm sure there's
	 * a way to turn these into labels but I don't feel like looking it up right
	 * now.
	 * 
	 * 0 = no drop
	 * 1 = small health pack
	 * */
	private int itemDropped = 0;

	// Use this for initialization
	void Start () {
		float prob = Random.Range(0.0f, 1.0f);
		// Subtract the rate of each item. If it is <= 0 afterward, drop that item.
		prob -= smallHealthRate;
		if (prob <= 0 && itemDropped == 0) {
			itemDropped = 1;
		}
		prob -= trophyRate;
		if (prob <= 0 && itemDropped == 0) {
			itemDropped = 2;
		}
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnDisable(){
		if (itemDropped == 1) {
			// Make a small health pack, put it here
			Instantiate(smallHealth, GetComponent<Rigidbody2D>().transform.position, Quaternion.identity);
		}
	}*/


	// Putting this here because I don't have time
	void OnTriggerEnter2D(Collider2D collide) {

		if (collide.gameObject.CompareTag ("PlayerBullet")) {
			audioSource.PlayOneShot(hitSound, .4F);
			enemyHealth -= 1;
			if (GlobalVars.bulletPowerUp) {
				enemyHealth -= 1;
			}
			GameObject.Destroy (collide.gameObject);
		} else if (collide.gameObject.CompareTag ("PlayerBulletCharged")) {
			audioSource.PlayOneShot(hitSound, .7F);
			enemyHealth -= 3;
			if (GlobalVars.bulletPowerUp) {
				enemyHealth -= 3;
			}
			GameObject.Destroy (collide.gameObject);
		}

		if (enemyHealth <= 0) {
			
			GameObject.Destroy (this.gameObject);
			GlobalVars.score += 10;
			if (itemDropped == 1) {
				// Make a small health pack, put it here
				Instantiate (smallHealth, GetComponent<Rigidbody2D> ().transform.position, Quaternion.identity);
			} else if (itemDropped == 2) {
				Instantiate (trophy, new Vector2 (95.81f, -8.71f), Quaternion.identity);
			}
		}

	}
}
