using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour
{
    public GameObject enemyGameObject;
    public GameObject SpritGameOject;
    public float spawnCooldown;
    public bool canspawn = true;
    public GameObject enemyGameObject2;
    public GameObject SpritGameOject2;
    public float spawnCooldown2;
    public bool canspawn2 = true;

    public float minValue;
    public float maxValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyGameObject != null && canspawn == true)
        {
            StartCoroutine(EnemySpawner());
            canspawn = false;
        }
        if (enemyGameObject2 != null && canspawn2 == true)
        {
            StartCoroutine(EnemySpawner2());
            canspawn2 = false;
        }

    }

    private IEnumerator EnemySpawner()
    {
        yield return new WaitForSeconds(spawnCooldown);
        if (minValue == 0 && maxValue == 0)
        {
            Instantiate(enemyGameObject, transform.position, Quaternion.identity);
            Instantiate(SpritGameOject, transform.position, Quaternion.identity);
        }
        else
        {
            Vector2 randomLocation = new Vector2(Random.Range(minValue, maxValue), transform.position.y);
            Instantiate(enemyGameObject, randomLocation, Quaternion.identity);
            Instantiate(SpritGameOject, randomLocation, Quaternion.identity);
        }
        canspawn = true;
    }
    private IEnumerator EnemySpawner2()
    {
        yield return new WaitForSeconds(spawnCooldown2);
        if (minValue == 0 && maxValue == 0)
        {
            Instantiate(enemyGameObject2, transform.position, Quaternion.identity);
            Instantiate(SpritGameOject2, transform.position, Quaternion.identity);
        }
        else
        {
            Vector2 randomLocation = new Vector2(Random.Range(minValue, maxValue), transform.position.y);
            Instantiate(enemyGameObject2, randomLocation, Quaternion.identity);
            Instantiate(SpritGameOject2, randomLocation, Quaternion.identity);
        }
        canspawn2 = true;
    }
}
