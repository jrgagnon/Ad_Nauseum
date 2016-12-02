using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	public static int score = 0;
	public static int playerHealth = 100;
	public static bool levelBossActive = false;
	public static bool bulletPowerUp = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void Reset () {
		score = 0;
		playerHealth = 100;
		levelBossActive = false;
		bulletPowerUp = false;
	}
}
