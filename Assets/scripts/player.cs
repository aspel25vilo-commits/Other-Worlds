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
    void Start()
    {
        rigiy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "floor")
        {
            canjump = true;
        }


    }


    private IEnumerator Jumpcoldown()
    {
        yield return new WaitForSeconds(jumpdelay);
        canjump = false;
    }

    
}
