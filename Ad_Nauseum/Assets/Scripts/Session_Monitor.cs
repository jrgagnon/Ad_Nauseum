using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Session_Monitor : MonoBehaviour {
	public readonly bool HL3_confirmed = true;

	public int earned_coins = 0; // Merge me!

	private float time_elapsed = -1f;
	private uint calls = 0;

	public static readonly string CALLS 				= "calls";
	public static readonly string EARNED_COINS 			= "earned_coins";

    private static Session_Monitor _instance = null;
    public static Session_Monitor Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Session_Monitor>();
            }
            return _instance;
        }
    }


    // Use this for initialization
    void Start () {

		this.time_elapsed = -1f; // Stays out of the table until the end lol

	}
	void Update()
    {
        if ( Input.GetKeyDown("escape") )
        { // Exit
            this.End();
        }
    }

	// COUNTS
	void FixedUpdate() {
		this.time_elapsed += Time.fixedDeltaTime;
	}

	public void Add_Coins(uint amt){
		this.earned_coins += (int)amt;
		this.calls++;
	}

	public float getElapsed(){
		return this.time_elapsed;
	}

	public void End(){
		// End the session_monitor

		//Destory( this.gameObject );

		// EXPORT STATS TO MAIN!
	}
}
