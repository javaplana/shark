using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objects;

    public float timeBetweenSpawns = 1.0f;
    private float currentTimeSpawn;

    public int spawnQuantity = 1;

    public bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeSpawn = timeBetweenSpawns;

        if (objects.Length <= 0) {
            canSpawn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSpawn) {
            return;
        }

        if (currentTimeSpawn <= 0.0f) {
            currentTimeSpawn = timeBetweenSpawns;

            int index = Random.Range(0, objects.Length);
            Instantiate(objects[index], new Vector3(11f, Random.Range(-3.0f, 3.0f) ,0f), Quaternion.identity);
        }

        currentTimeSpawn -= Time.deltaTime;
    }
}
