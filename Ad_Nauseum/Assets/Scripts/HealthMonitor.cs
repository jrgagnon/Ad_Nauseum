using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthMonitor : MonoBehaviour
{

    public static int HP = 100;
    public static int MaxHP = 100;

    protected float last_time = -1f;
    protected float fire_threshold = 0.045f;

    public bool DEBUG_Bleedout_on = false;

    public GameObject Player;
    public Collider2D Collison;
    public Rigidbody2D RBody;
    public Session_Monitor Ses; // Optional

    // Use this for initialization
    void Start()
    {
        Ses = Session_Monitor.Instance;
        {
            // If the starting HP is not set, set as total
            // So people dont die RIGHT at start
           HP += MaxHP;

            if (Player == null)
            {
                Debug.Log("[!] Player gameobj NOT linked in HEALTH MONITOR!  Please attach object or talk to Brett!");
            }
            if (Collison == null)
            {
                Collison = Player.GetComponent<Collider2D>();
            }
            if (RBody == null)
            {
                RBody = Player.GetComponent<Rigidbody2D>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //t.text = "Hp: " + HP + "\nStamina: " + Stamina + "\nFuel:" + Flame;
        if (this.IsDead)
        {
            this.Ses.End();
        }
    }

    void FixedUpdate()
    {
        // In addition to physics...
        // Fixed interval regen will be handled here
        if (DEBUG_Bleedout_on == true)
        {
            HP -= 1;
            //Debug.Log("[i] Bleeding... -1 -> "+this.HP);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            this.last_time = Time.time;
        } else if(Input.GetButtonUp("Fire2") && this.last_time > Time.time) {
            if (this.last_time > Time.time + fire_threshold)
            {
                // Charged
                //@@@FireCodeHere
                float amt = (Time.time - this.last_time);

            }
            else
            {
                // Too quick, lesser
                //@@@FireCodeHere

            }
            this.last_time = -1f;
        }
        
    }

    public bool IsAlive 
    { // Attribute
        get { return HP > 0; }
    }
    public bool IsDead
    {
        get { return !this.IsAlive; }
    }

    public void ChangeHP(int dmg)
    {

        // You will notice, the damage is added...
        HP -= dmg;

        // Check to make sure we didnt just die lol

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //int dmg = 0; // coll.gameObject.getDamage
        //dmg = (int)Mathf.Abs(this.RBody.velocity.magnitude);

        // Please make these globals!!!
        bool IsEnemy = coll.gameObject.tag == "Enemy";
        bool IsItem = coll.gameObject.tag == "Item";
        bool IsWorld = coll.gameObject.tag == "World";

        //bool IsOtherDead = (dmg > 5);
        GameObject Other = coll.gameObject;

        // coll.gameObject
        // @@@Need flag based on what we hit...
        /*
        if (IsEnemy)
        {
            // Its an enemy, so we'll take damage.
            // Damage is NEGATED for simplicity here!!!
            ChangeHP(dmg);
            if (IsOtherDead)
            {
                Destroy(Other); // Check me
            }

        }else */

        if (IsItem)
        {
            // @@@

        }
    }

    void OnCollisionExit2D(Collider coll)
    {
        bool IsEnemy = coll.gameObject.tag == "Enemy";
        bool IsItem = coll.gameObject.tag == "Item";
        bool IsWorld = coll.gameObject.tag == "World";

        if (IsEnemy || IsWorld)
        {
            // Because you cant just take damage on ground
            Debug.Log("Off ground");
        }
    }
// END OF FILE
}
// Nothing