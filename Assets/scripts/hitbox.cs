using UnityEngine;

public class hitbox : MonoBehaviour
{
    skelk skely;
    
    public 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skely = GetComponent<skelk>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "sword")
        {
            skely.Entakedamage();

        }
    }
}
