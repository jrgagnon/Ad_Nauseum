using UnityEngine;
using System.Collections;

public class BossStart : MonoBehaviour {

	private float currentz;
	private bool active;
	public GameObject wall;
	public GameObject boss;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (active) {
			
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			GameObject.Find ("Main Camera").transform.position -= new Vector3 (0, 0, 2);
			this.active = true;
			GlobalVars.levelBossActive = true;
			Instantiate (wall, new Vector2 (86.78f, -5.58f), Quaternion.identity);
			Instantiate (boss, new Vector2 (99.39f, 2.25f), Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
