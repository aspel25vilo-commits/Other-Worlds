using UnityEngine;
using System.Collections;

public class boss : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float leftBoundary = -8f;
    public float rightBoundary = 8f;
    public float attackdelay = 1f;
    public float attackdelay2 = 1f;
    public float attackdelay10 = 1f;
    public float attackdelay11 = 1f;
    public float animationdelay = 1f;
    public float enhealth = 15;
    public Animator objAnimator;
    public GameObject txtobj;

    private int moveDirection = 1;
    private bool isMoving = false;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private const float AttackInterval = 3f;

    void Start()
    {
        txtobj = GameObject.Find("pointcounter");
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Enter());
    }

    void Update()
    {
        
        if (enhealth < 1)
        {
            txtobj.GetComponent<points>().addpoints(1);
            Destroy(this.gameObject);
        }
        if (!isMoving) return;

        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);

        if (transform.position.x >= rightBoundary)
            moveDirection = -1;
        else if (transform.position.x <= leftBoundary)
            moveDirection = 1;

        spriteRenderer.flipX = moveDirection == -1;
    }

    /// <summary>Plays the enter animation then starts normal boss behaviour.</summary>
    private IEnumerator Enter()
    {
        isMoving = false;
        yield return new WaitForSeconds(animationdelay);
        objAnimator.SetBool("enter", false);
        isMoving = true;
        StartCoroutine(Attack());
    }

    /// <summary>Loops the attack decision cycle.</summary>
    private IEnumerator Attack()
    {
        while (true)
        {
            
            attackdelay11 = Random.Range(1f, 3f);
            yield return new WaitForSeconds(attackdelay11);

            int dice = Random.Range(1, 7);
            if (dice < 6)
            {
                
                yield return StartCoroutine(Attackcoldown());
            }
                
            else
            {
                
                yield return StartCoroutine(Attackcoldown2());
            }
        }
    }

    /// <summary>Boss dives down and returns.</summary>
    private IEnumerator Attackcoldown()
    {
        
        isMoving = false;
        yield return new WaitForSeconds(attackdelay);
        transform.position += Vector3.down * 4;
        yield return new WaitForSeconds(attackdelay2);
        transform.position += Vector3.up * 4;
        isMoving = true;
        
    }

    /// <summary>Boss plays attack animation.</summary>
    private IEnumerator Attackcoldown2()
    {
        
        
        isMoving = false;
        objAnimator.SetBool("attack", true);
        yield return new WaitForSeconds(attackdelay10);
        objAnimator.SetBool("attack", false);
        isMoving = true;
    }

    private void Entakedamage()
    {
        enhealth--;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("s");
        if (other.gameObject.tag == "sword")
            Debug.Log("sfa");
            Entakedamage();
    }
}
