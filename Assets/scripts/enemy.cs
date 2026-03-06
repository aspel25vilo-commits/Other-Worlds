using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    bool canattack = true;
    public float attackdelay;
    public float animationdelay;
    public float Speed = 100;
    Vector2 move = new Vector2(1f, 1f);
    public GameObject play;
    public Animator objAnimator;
    public SpriteRenderer fhillip;
    public float enhealth = 1;
    void Start()
    {
        objAnimator = GetComponent<Animator>();
        fhillip = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Attackcoldown());
       

    }

    
    void Update()
    {
        if (move.x < 0)
        {
            fhillip.flipX = true;
        }
        if (move.x > 0)
        {
            fhillip.flipX = false;
        }
        move = play.transform.position - transform.position;
        if (enhealth < 1)
        {
            Destroy(this.gameObject);
        }
        
    }

    private IEnumerator Attackcoldown()
    {
        while (true)
        {
            
            rb.AddForce(move.normalized * Speed);
            objAnimator.SetBool("attack", true);
            yield return new WaitForSeconds(animationdelay);
            objAnimator.SetBool("attack", false);

            yield return new WaitForSeconds(attackdelay);
            
        }

    }
    private void entakedamage()
    {
        enhealth--;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "sword")
        {
            entakedamage();
            
        }
    }

}
