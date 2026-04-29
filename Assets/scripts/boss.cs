using UnityEngine;
using System.Collections;

public class boss : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float leftBoundary = -8f;
    public float rightBoundary = 8f;
    public float move = 3f;
    Rigidbody2D rb;
    public float attackdelay;
    public float down = 1f;
    public float attackdelay2 = 1f;
    public float attackdelay10 = 1f;
    public float attackdelay11 = 1f;
    public float upe = 1f;
    public Animator objAnimator;
    public float animationdelay = 1f;
    private bool pause = false;
    public float enhealth = 15;

    private int moveDirection = 1;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        StartCoroutine(Enter());
        StartCoroutine(Attackcoldown());
        StartCoroutine(Attackcoldown2());
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        
            StartCoroutine(Attackcoldown2());
        

            transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);

            if (transform.position.x >= rightBoundary)
            {
                moveDirection = -1;
            }
            else if (transform.position.x <= leftBoundary)
            {
                moveDirection = 1;
            }

            spriteRenderer.flipX = moveDirection == -1;
 
    }

    private const float AttackInterval = 3f;

    private IEnumerator Attackcoldown()
    {
        float originalMoveSpeed = moveSpeed;

       
  

            yield return new WaitForSeconds(AttackInterval);

            moveSpeed = 0f;
            yield return new WaitForSeconds(attackdelay);
            transform.position += (Vector3.down * 4);
            yield return new WaitForSeconds(attackdelay2);
            transform.position += (Vector3.up * 4);

            moveSpeed = originalMoveSpeed;
        yield return null;
        
    }
    private IEnumerator Enter()
    {
        

        while (true)
        {
            float originalMoveSpeed = moveSpeed;
            move = 0f;
            down = 0f;
            upe = 0f;
            
            yield return new WaitForSeconds(animationdelay);
            objAnimator.SetBool("enter", false);
            StartCoroutine(Attackcoldown());
            pause = true;
            moveSpeed = originalMoveSpeed;
        }
    }

    private void Entakedamage()
    {
        enhealth--;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "sword")
        {
            Entakedamage();

        }
    }

    private IEnumerator Attackcoldown2()
    {
        

        
        
            Debug.Log("testing");
            move = 0f;
            down = 0f;
            upe = 0f;

             objAnimator.SetBool("attack", true);
             yield return new WaitForSeconds(attackdelay10);
             objAnimator.SetBool("attack", false);
            attackdelay11 = Random.Range(1f, 3f);
             yield return new WaitForSeconds(attackdelay11);
        yield return null;




        
    }

    private IEnumerator Attack()
    {
        while(true)
        {
            int dice = Random.Range(1, 7);
            if (dice < 6) 
            {
                StartCoroutine(Attackcoldown());
            }
            else
            {
                StartCoroutine(Attackcoldown2());
            }
        }
        yield return null;
    }

}
