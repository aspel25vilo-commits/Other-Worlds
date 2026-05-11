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

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip death;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            if (!audioSource.isPlaying)
            {
                audioSource.clip = death;
                audioSource.Play();

            }
            // audioSource.PlayOneShot(death);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Attackcoldown()
    {
        while (true)
        {
            //Kolla om han �r p� marken.
            //
            rb.AddForce((move + Vector2.up * 2).normalized * Speed);
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
