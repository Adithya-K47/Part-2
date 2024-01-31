using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planespawner : MonoBehaviour
{

    public GameObject newplane;
    
    public float minSpawnTime;
    
    public float maxSpawnTime;

    public float timeTillSpawn;

    public float randomRotation;
    // Start is called before the first frame update
    void Start()
    {
        Timeuntilspawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeTillSpawn -= Time.deltaTime;

        if(timeTillSpawn <= 0)
        {
            Instantiate(newplane, transform.position, randomRotation);
            Timeuntilspawn();
        }
    }
     
    private void Timeuntilspawn()
    {
        timeTillSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
