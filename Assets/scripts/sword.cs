using UnityEngine;
using System.Collections;

public class sword : MonoBehaviour
{
    public Animator objAnimator;
    public float attackdelay;
   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        objAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Jumpcoldown());
            objAnimator.SetBool("attack", true);

        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {

            objAnimator.SetBool("attack", false);
            objAnimator.SetBool("upattack", true);
            StartCoroutine(Jumpcoldown());
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.S))
        {

            objAnimator.SetBool("attack", false);
            objAnimator.SetBool("upattack", true);
            StartCoroutine(Jumpcoldown());
        }

    }

    private IEnumerator Jumpcoldown()
    {
        yield return new WaitForSeconds(attackdelay);
        objAnimator.SetBool("attack", false);
        objAnimator.SetBool("upattack", false);
    }
}

