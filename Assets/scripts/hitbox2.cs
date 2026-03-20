using UnityEngine;

public class hitbox2 : MonoBehaviour
{
    enemy2 skel;

    public
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skel = GetComponent<enemy2>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "sword")
        {
            skel.Entakedamage();


        }
    }
}
