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
    public float upe = 1f;
    public Animator objAnimator;
    public float animationdelay = 1f;
    private bool pause = false;
    public float enhealth = 15;

    private int moveDirection = 1;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
        StartCoroutine(Attackcoldown());
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Enter());
    }

    void Update()
    {
        if (move > 0)
        {
            StartCoroutine(Attackcoldown2());
        }

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

        while (true)
        {

            yield return new WaitForSeconds(AttackInterval);

            moveSpeed = 0f;
            yield return new WaitForSeconds(attackdelay);
            transform.position = Vector3.down * down;
            yield return new WaitForSeconds(attackdelay2);
            transform.position = Vector3.up * upe;

            moveSpeed = originalMoveSpeed;
        }
    }
    private IEnumerator Enter()
    {
        

        while (true)
        {
            move = 0f;
            down = 0f;
            upe = 0f;
            
            yield return new WaitForSeconds(animationdelay);
            objAnimator.SetBool("enter", false);
            pause = true;
            move = 3f;
            down = 1f;
            upe = 3f;
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
        

        while (true)
        {
            objAnimator.SetBool("attack", true);
            yield return new WaitForSeconds(attackdelay10);
            objAnimator.SetBool("attack", false);


        }
    }

}
