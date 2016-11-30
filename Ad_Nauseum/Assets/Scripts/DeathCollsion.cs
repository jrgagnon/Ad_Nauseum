using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathCollsion : MonoBehaviour {

	// Timers for invincibility
	public float isecs;
	private float itimer;
	public float blinkTime;
	private float blinkClock;

	// Use this for initialization
	void Start () {
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
				Application.LoadLevel (Application.loadedLevel);
				HealthMonitor.HP = HealthMonitor.MaxHP;
				//}
			} else if (other.gameObject.CompareTag ("Enemy")) {
				// Need to add code to freeze enemy for a moment after the player hits it, to make damage less frustrating
				HealthMonitor.HP -= 20;
				itimer = isecs;
				Movement.stagger = true;
				Movement.staggerdir = Mathf.Sign (GetComponent<Rigidbody2D> ().position.x - other.attachedRigidbody.position.x);
				if (HealthMonitor.HP <= 0) {
					Application.LoadLevel (Application.loadedLevel);
					HealthMonitor.HP = HealthMonitor.MaxHP;
				}
			} else if (other.gameObject.CompareTag ("EnemyBullet")) {
				HealthMonitor.HP -= 15;
				itimer = isecs;
				Movement.stagger = true;
				Movement.staggerdir = Mathf.Sign (GetComponent<Rigidbody2D> ().position.x - other.attachedRigidbody.position.x);
				if (HealthMonitor.HP <= 0) {
					Application.LoadLevel (Application.loadedLevel);
					HealthMonitor.HP = HealthMonitor.MaxHP;
				}
			}
		}
	}
}
