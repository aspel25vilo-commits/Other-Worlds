using UnityEngine;
using System.Collections;

public class enemy2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed = 100;
    public GameObject player;
    Vector2 move = new Vector2(1f, 1f);
    public float en2health = 1;
    public GameObject txtobj;
    public Animator objAnimator;
    public float attackdelay;
    public float animationdelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txtobj = GameObject.Find("pointcounter");
        rb = GetComponent<Rigidbody2D>();
        objAnimator = GetComponent<Animator>();
        StartCoroutine(Attackcoldown());
    }

    private void Awake()
    {

        player = GameObject.Find("player").gameObject;
        move = player.transform.position - transform.position;
        move = move.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            move = player.transform.position - transform.position;
            move = move.normalized;
        }
        
        if (en2health < 1)
        {
            txtobj.GetComponent<points>().addpoints(1);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Attackcoldown()
    {
        while (true)
        {
            //Kolla om han är på marken.
            //
            rb.AddForce((move + Vector2.up).normalized * Speed);
            objAnimator.SetBool("attack", true);
            yield return new WaitForSeconds(animationdelay);
            objAnimator.SetBool("attack", false);

            yield return new WaitForSeconds(attackdelay);

        }

    }
    public void Entakedamage()
    {
        en2health--;

    }
}
