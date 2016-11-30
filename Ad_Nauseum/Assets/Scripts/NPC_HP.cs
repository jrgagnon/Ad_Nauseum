using UnityEngine;
using System.Collections;

public class NPC_HP : MonoBehaviour {
    // NPC Lightweight HP monitor

    public GameObject NPC;
    public int Total_HP = 3;
    public bool IsBleeding = false;
    protected int Current_HP = 1;

    public static int HP_LIMIT = 350;

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

    public void SetHP(float amt)
    {
        SetHP(Mathf.RoundToInt(amt));
    }

    public void SetHP(int amt)
    {
        // Might be needed...
        this.Current_HP = Mathf.Clamp(this.Current_HP + amt, -1, Total_HP);
    }

    public void SetTotalHP(float amt)
    {
        SetTotalHP(Mathf.RoundToInt(amt));
    }

    public void SetTotalHP(int amt)
    {
        // Set the MAX HP
        // This may be needed
        // If you wish to buff 
        // and NPC midgame
        this.Total_HP = Mathf.Clamp(this.Total_HP + amt, 0, HP_LIMIT);
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
        Damage(Mathf.RoundToInt(amt));
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
