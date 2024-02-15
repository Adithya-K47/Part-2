using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }

    public void Res1()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }

    public void Res2()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }
}
