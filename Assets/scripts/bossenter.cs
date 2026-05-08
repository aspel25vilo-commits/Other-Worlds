using UnityEngine;
using System.Collections;
public class bossenter : MonoBehaviour
{
    public float detch;
    public float downspace = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Vector3.down * downspace;
        StartCoroutine(Attackcoldown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Attackcoldown()
    {
        while (true)
        {


            yield return new WaitForSeconds(detch);
            Destroy(gameObject);


        }
    }
}
