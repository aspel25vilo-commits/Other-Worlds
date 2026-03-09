using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator objAnimator;
    public SpriteRenderer fhillip;
    public float enhealth = 1;
    public GameObject txtobj;
    Vector2 move = new Vector2(1f, 1f);
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objAnimator = GetComponent<Animator>();
        fhillip = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
        txtobj = GameObject.Find("pointcounter");
    }
    private void Awake()
    {

        player = GameObject.Find("player").gameObject;
    }

    // Update is called once per frame
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
        if (enhealth < 1)
        {
            txtobj.GetComponent<points>().addpoints(1);
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.right * move * Time.deltaTime);
    }

    private void Entakedamage()
    {
        enhealth--;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "sword")
        {
            Entakedamage();

        }
    }
}
