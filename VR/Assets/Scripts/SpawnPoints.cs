using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{

    [SerializeField]
    private GameObject[] spawnPoints;
    [SerializeField]
    private GameObject[] typesOfPeople;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 10f;

    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPeople());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPeople()
    {
        while (stop == false)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            GameObject person = Instantiate(typesOfPeople[Random.Range(0, typesOfPeople.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform);
            Destroy(person.gameObject, 5); //Igual destruir en un Random.Range de segundos
        }
    }

    public void Stop()
    {
        stop = true;
    }
}
