using UnityEngine;
using System.Collections;

public class NPC_HP : MonoBehaviour {
    // NPC Lightweight HP monitor

    public GameObject NPC;
    public int Total_HP = 3;
    public bool IsBleeding = false;
    protected int Current_HP;

	// Use this for initialization
	void Start () {
        if (Total_HP > 0)
        {
            this.Current_HP = Total_HP;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (!IsBleeding) { return; }
        this.Damage(-1);
	}

    bool isDead()
    {
        return !isAlive();
    }

    bool isAlive()
    {
        return this.Current_HP > 0;
    }

    void Damage(float amt)
    {
        Damage(Mathf.Round(amt));
    }

    void Damage(int amt)
    {
        this.Current_HP -= amt;
        
        //@@@ Damage Sound here!
        if (isDead())
        {
            this.Death();
        }
    }

    void Death()
    {
        // Death Sound
        GameObject.Destroy(this.NPC);
    }
}
