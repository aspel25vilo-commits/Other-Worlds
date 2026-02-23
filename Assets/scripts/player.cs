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
    void Start()
    {
        objAnimator = GetComponent<Animator>();
        fhillip = GetComponent<SpriteRenderer>();
        rigiy = GetComponent<Rigidbody2D>();
        fhill = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
  
      

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


    }


    private IEnumerator Jumpcoldown()
    {
        yield return new WaitForSeconds(jumpdelay);
        canjump = false;
    }

    
}
