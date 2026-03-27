using UnityEngine;

public class skelk : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator objAnimator;
    public SpriteRenderer fhillip;
    public float enhealth = 1;
    public GameObject txtobj;
    Vector2 move = new Vector2(1f, 1f);
    public GameObject player;
    damgepro immunityHandler;

    void Start()
    {
        objAnimator = GetComponent<Animator>();
        fhillip = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        immunityHandler = GetComponent<damgepro>();
        txtobj = GameObject.Find("pointcounter");
    }

    private void Awake()
    {
        player = GameObject.Find("player").gameObject;
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
        if (enhealth < 1)
        {
            txtobj.GetComponent<points>().addpoints(1);
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.right * move * Time.deltaTime);
    }

    /// <summary>
    /// Apply one point of damage if not currently immune.
    /// </summary>
    public void Entakedamage()
    {
        if (immunityHandler == null || !immunityHandler.IsImmune)
        {
            enhealth--;
            immunityHandler?.OnDamageReceived();
        }
    }
}
