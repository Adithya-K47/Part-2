using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resmanager : MonoBehaviour
{
    public int width;
    public int height;

    public void SetWidth(int newWidth)
    {
        width = newWidth;
    }
    public void SetHeight(int newHeight)
    {
        height = newHeight;
    }
    public void SetRes()
    {
        Screen.SetResolution(width, height, false);
    }
}
