using UnityEngine;
using System.Collections;
using UnityEditor;

public class player : MonoBehaviour
{
    public float playerspeed;
    public float jumpspeed;
    public bool canjump = true;
    public float jumpdelay;
    Rigidbody2D rigiy;
    public Animator objAnimator;
    public SpriteRenderer fhillip;
    private SpriteRenderer fhill;
    public float health = 3;
    private GameObject life3;
    private GameObject life2;
    private GameObject life1;
    public GameObject txtobjc;

    void Start()
    {
        objAnimator = GetComponent<Animator>();
        fhillip = GetComponent<SpriteRenderer>();
        rigiy = GetComponent<Rigidbody2D>();
        fhill = GetComponent<SpriteRenderer>();
        txtobjc = GameObject.Find("lifecounter");
    }
    private void Awake()
    {
        life3 = GameObject.Find("life3");
        life2 = GameObject.Find("life2");
        life1 = GameObject.Find("life1");
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
            transform.Translate(Vector3.left * playerspeed);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerspeed);

        }
        if (Input.GetKey(KeyCode.W))
        {
            if (canjump == true)
            {

                StartCoroutine(Jumpcoldown());
                transform.Translate(Vector3.up * jumpspeed);
            }
            
        
        }
        if (canjump == true)
        {
            rigiy.gravityScale = 0;
        }
        if (canjump == false)
        {
            rigiy.gravityScale = 1;
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

        if (other.gameObject.tag == "enemy")
        {
            takedamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            takedamage();
        }

    }


    private IEnumerator Jumpcoldown()
    {
        yield return new WaitForSeconds(jumpdelay);
        canjump = false;
    }
    private void takedamage()
    {
        health--;
        if (health < 3)
        {
            life3.SetActive(false);
        }
        if (health < 2)
        {
            life2.SetActive(false);
        }
        if (health < 1)
        {
            life1.SetActive(false);
        }
    }


}
