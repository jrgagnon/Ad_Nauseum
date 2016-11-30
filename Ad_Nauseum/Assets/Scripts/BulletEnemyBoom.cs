using UnityEngine;
using System.Collections;

public class BulletEnemyBoom : MonoBehaviour {

    public int dmg = 1;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collide) {

		if (collide.gameObject.CompareTag("EvilTrigger")) {

			Debug.Log ("Boom");

			Destroy (this.gameObject);
		} else if (collide.gameObject.CompareTag("Enemy")){

			Debug.Log ("NPC HIT");
            collide.gameObject.GetComponent<NPC_HP>().Damage(dmg);
		}

	}
}
