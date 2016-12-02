using UnityEngine;
using System.Collections;

public class DestroyOffscreen : MonoBehaviour {

	private bool appeared;

	// Use this for initialization
	void Start () {
		appeared = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameVisible(){
		appeared = true;
	}

	void OnBecameInvisible(){
		if (appeared) {
			Destroy (this.gameObject);
		}
	}
}
