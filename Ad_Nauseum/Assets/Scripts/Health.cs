using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public float threshold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVars.playerHealth < threshold) {
			this.GetComponent<Image>().enabled = false;
		} else {
			this.GetComponent<Image>().enabled = true;
		}
	}
}
