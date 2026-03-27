using UnityEngine;

public class hitbox : MonoBehaviour
{
    skelk skely;
    
    void Start()
    {
        skely = GetComponentInParent<skelk>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "sword")
        {
            skely.Entakedamage();
        }
    }
}
