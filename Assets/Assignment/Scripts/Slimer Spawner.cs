using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class SlimerSpawner : MonoBehaviour
{
    public GameObject slime;
    public float maxr = 5;
    public float minr = -5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SlimeSpawn()
    {
        Instantiate(slime, new Vector3(-9, Random.Range(minr, maxr), 0), transform.rotation);
    }
}
