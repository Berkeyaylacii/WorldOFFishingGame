using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner4 : MonoBehaviour
{
    public GameObject boat;

    public GameObject Fish7;
    public GameObject Fish8;

    public bool stopSpawning7 = false;
    public bool stopSpawning8 = false;

    public float spawnTime;
    public float spawnDelay;

    public int fishCounter7;
    public int fishCounter8;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFish7", spawnTime, spawnDelay);
        InvokeRepeating("SpawnFish8", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(stopSpawning7 == true && fishCounter7 < 10)
        {
            InvokeRepeating("SpawnFish7", 1, 3);
            stopSpawning7 = false;
        }

        if (stopSpawning8 == true && fishCounter8 < 10)
        {
            InvokeRepeating("SpawnFish8", 1, 3);
            stopSpawning8 = false;
        }
    }

    public void SpawnFish7()
    {
        Vector3 position = new Vector3(Random.Range(54.5F, 55F), 1, Random.Range(-9F, -9.5F));  //Random spawn area
        if (Fish7 != null)
        {
            Instantiate(Fish7, position, Quaternion.identity);
        }
        fishCounter7++;

        if (fishCounter7 > 10)
        {
            CancelInvoke("SpawnFish7");
            stopSpawning7 = true;
        }
    }

    public void SpawnFish8()
    {
        Vector3 position = new Vector3(Random.Range(54.5F, 55F), 1, Random.Range(-35F, -35.5F));  //Random spawn area
        if (Fish8 != null)
        {
            Instantiate(Fish8, position, Quaternion.identity);
        }
        fishCounter8++;

        if (fishCounter8 > 10)
        {
            CancelInvoke("SpawnFish8");
            stopSpawning8 = true;
        }
    }
}
