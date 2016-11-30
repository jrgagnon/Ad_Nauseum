using UnityEngine;
using System.Collections;

public class NPC_HP : MonoBehaviour {
    // NPC Lightweight HP monitor

    public GameObject NPC;
    public int Total_HP = 3;
    public bool IsBleeding = false;
    protected int Current_HP = 1;

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

    public bool isDead()
    {
        return !isAlive();
    }

    public bool isAlive()
    {
        return this.Current_HP > 0;
    }

    public void Damage(float amt)
    {
        Damage(Mathf.Round(amt));
    }

    public void Damage(int amt)
    {
        this.Current_HP -= amt;
        
        //@@@ Damage Sound here!
        if (isDead())
        {
            this.Death();
        }
    }

    public void Death()
    {
        // Death Sound
        GameObject.Destroy(this.NPC);
    }
}
