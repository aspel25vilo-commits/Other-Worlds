using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    public float playerspeed;
    public float jumpspeed;
    public bool canjump = true;
    public float jumpdelay;
    void Start()
    {
        
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
