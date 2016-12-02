using UnityEngine;
using System.Collections;

public class BreakWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("PlayerBulletCharged")) {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
