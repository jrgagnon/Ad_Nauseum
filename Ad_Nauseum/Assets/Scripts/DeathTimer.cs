using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathTimer : MonoBehaviour {

	private float maxTime;
	private float startTime;

	public AudioClip deathSound;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.PlayOneShot (deathSound, 1F);
		maxTime = 3f;
		startTime = Time.time;
		GlobalVars.levelBossActive = false;
		GlobalVars.bulletPowerUp = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= maxTime) {
			HealthMonitor.HP = HealthMonitor.MaxHP;
			SceneManager.LoadScene ("Demo_Level");
		}
	}
}
