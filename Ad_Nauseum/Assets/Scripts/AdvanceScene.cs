using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AdvanceScene : MonoBehaviour {

	// Toggle if this is the title screen
	public bool title;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (!title) {
				SceneManager.LoadScene ("TitleScreen");
			}
		}

		if (Input.GetButtonDown ("Fire1")) {
			if (title){
				SceneManager.LoadScene ("Demo_Level");
			}
		}
	}
}
