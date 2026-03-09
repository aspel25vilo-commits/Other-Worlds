using UnityEngine;
using System.Collections;


public class hole : MonoBehaviour
{
    public float detch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
