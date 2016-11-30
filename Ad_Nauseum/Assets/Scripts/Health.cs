using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public float threshold;
	private Image banana;
	private Vector2 size;
	// Use this for initialization
	void Start () {
		banana = this.gameObject.GetComponent<Image> ();
		size = banana.rectTransform.sizeDelta;
	}
	
	// Update is called once per frame
	void Update () {

		float x = HealthMonitor.HP * .01f;
		banana.rectTransform.sizeDelta = new Vector2 (size.x * x, size.y);

		/*if (HealthMonitor.HP < threshold) {
			this.GetComponent<Image>().enabled = false;
		} else {
			this.GetComponent<Image>().enabled = true;
		}*/
	}
}
