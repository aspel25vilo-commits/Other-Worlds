using System.Collections;
using System.Drawing;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    bool canattack = true;
    public float attackdelay;
    public float animationdelay;
    public float Speed = 100;
    Vector2 move = new Vector2(1f, 1f);
    public GameObject player;
    public Animator objAnimator;
    public SpriteRenderer fhillip;
    public float enhealth = 1;
    public GameObject txtobj;


    [Header("Audio")]
    [SerializeField] private AudioSource audioSousce;
    [SerializeField] private AudioClip death;
    void Start()
    {
        objAnimator = GetComponent<Animator>();
        fhillip = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Attackcoldown());
        txtobj = GameObject.Find("pointcounter");

    }
    private void Awake()
    {

        player = GameObject.Find("player").gameObject;
        move = player.transform.position - transform.position;
        move = move.normalized;
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
        move = player.transform.position - transform.position;
        move = move.normalized;
        if (enhealth < 1)
        {
            txtobj.GetComponent<points>().addpoints(1);
            audioSousce.PlayOneShot(death);
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

}
