using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject axeobject;
    public float maxr = 5;
    public float minr = -5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void SpawningAxe()
    {
        Instantiate(axeobject, new Vector3 (-9, Random.Range(minr, maxr), 0), transform.rotation);
    }
}
