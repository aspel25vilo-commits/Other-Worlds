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
    public GameObject enemyGameObject3;
    public GameObject SpritGameOject3;
    public float spawnCooldown3;
    public bool canspawn3 = true;
    public GameObject enemyGameObjectboss;
    public GameObject SpritGameOjectboss;
    public float spawnCooldownboss;
    public float entercooldown;
    public bool canspawnboss = true;
    public bool theendcoldown = true;
    public float thndcoldown;

    public float minValue;
    public float maxValue;
    public float minValue2;
    public float maxValue2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Theend());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyGameObject != null && canspawn == true && theendcoldown == true)
        {
            StartCoroutine(EnemySpawner());
            canspawn = false;
        }
        if (enemyGameObject2 != null && canspawn2 == true && theendcoldown == true)
        {
            StartCoroutine(EnemySpawner2());
            canspawn2 = false;
        }
        if (enemyGameObject3 != null && canspawn3 == true && theendcoldown == true)
        {
            StartCoroutine(EnemySpawner3());
            canspawn3 = false;
        }
         if (enemyGameObjectboss != null && canspawnboss == true && theendcoldown == true)
        {
            StartCoroutine(EnemySpawnerboss());
            canspawnboss = false;
        }

    }
    private IEnumerator Theend()
    {
        yield return new WaitForSeconds(thndcoldown);
        theendcoldown = false;
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
    private IEnumerator EnemySpawner3()
    {
        yield return new WaitForSeconds(spawnCooldown3);
        if (minValue == 0 && maxValue == 0)
        {
            Instantiate(enemyGameObject3, transform.position, Quaternion.identity);
            Instantiate(SpritGameOject3, transform.position, Quaternion.identity);
        }
        else
        {
            Vector2 randomLocation = new Vector2(Random.Range(minValue, maxValue), transform.position.y);
            Instantiate(enemyGameObject3, randomLocation, Quaternion.identity);
            Instantiate(SpritGameOject3, randomLocation, Quaternion.identity);
        }
        canspawn3 = true;
    }

        private IEnumerator EnemySpawnerboss()
    {
        minValue2 = 7;
        maxValue2 = 6;
        yield return new WaitForSeconds(spawnCooldownboss);
        if (minValue2 == 7 && maxValue2 == 6)
        {
            Instantiate(SpritGameOjectboss, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(entercooldown);
            Instantiate(enemyGameObjectboss, transform.position, Quaternion.identity);
            
        }
        else
        {
            Vector2 randomLocation = new Vector2(Random.Range(minValue, maxValue), transform.position.y);
            Instantiate(SpritGameOjectboss, randomLocation, Quaternion.identity);
            yield return new WaitForSeconds(entercooldown);
            Instantiate(enemyGameObjectboss, randomLocation, Quaternion.identity);
            
        }
        canspawnboss = true;
    }
}
