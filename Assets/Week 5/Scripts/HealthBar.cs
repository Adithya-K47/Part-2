using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Knight knight;

    public void Start()
    {
        knight = GetComponent<Knight>();
    }

    public void Update()
    {
        slider.value = knight.health;
    }
   
}
