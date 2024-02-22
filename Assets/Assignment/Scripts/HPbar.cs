using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    public Slider slider;
    public Ghost ghost;
    // Start is called before the first frame update
    void Start()
    {
        ghost = GetComponent<Ghost>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = ghost.hp;
    }
}
