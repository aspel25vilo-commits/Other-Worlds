using Mono.Cecil;
using UnityEngine;

public class hitbox2 : MonoBehaviour
{
    enemy2 skel;

    public
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skel = GetComponentInParent<enemy2>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "sword")
        {
            skel.Entakedamage();



        }
    }
}
