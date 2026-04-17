using UnityEngine;
using UnityEditor;

public class player : MonoBehaviour
{
    public float playerspeed;
    public float jumpspeed;
    public bool canjump = true;
    Rigidbody2D rigiy;
    public Animator objAnimator;
    public SpriteRenderer fhillip;
    private SpriteRenderer fhill;
    public float health = 3;
    damgepro immunityHandler;

    

    void Start()
    {
        objAnimator = GetComponent<Animator>();
        fhillip = GetComponent<SpriteRenderer>();
        rigiy = GetComponent<Rigidbody2D>();
        fhill = GetComponent<SpriteRenderer>();
        immunityHandler = GetComponent<damgepro>();
    }
   

    // Update is called once per frame
    void Update()
    {
  
      
        if (health < 1)
        {
            Destroy(this.gameObject);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left.normalized * playerspeed);
            //rigiy.AddForce(playerspeed * Vector2.left.normalized);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right.normalized * playerspeed);
            //rigiy.AddForce(playerspeed * Vector2.right.normalized);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canjump == true)
            {
                canjump = false;
                rigiy.linearVelocity = new Vector2(rigiy.linearVelocity.x, 0f);
                rigiy.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);
            objAnimator.SetBool("runleft", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            
            transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.z);
            objAnimator.SetBool("runleft", true);
        }
        else
        {
            objAnimator.SetBool("runleft", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            
            objAnimator.SetBool("jump", true);
        }
        else
        {
            //objAnimator.SetBool("jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "floor")
        {
            objAnimator.SetBool("jump", false);
            canjump = true;
            

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Debug.Log("Denna kolliderar jag med: " + other.gameObject.name);
        }

        if (other.tag == "enemy")
        {
            if (immunityHandler == null || !immunityHandler.IsImmune)
            {
                Takedamage();
                immunityHandler?.OnDamageReceived();
            }
        }

    }


    private void Takedamage()
    {
        health--;
        if (health < 3)
        {
            Destroy(GameObject.FindWithTag("life3"));
        }
        if (health < 2)
        {
            Destroy(GameObject.FindWithTag("life2"));
        }
        if (health < 1)
        {
            Destroy(GameObject.FindWithTag("life1"));
        }
    }


}
