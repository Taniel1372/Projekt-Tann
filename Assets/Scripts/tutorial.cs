using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public Transform slides;
    public Vector3 pos;

    public void Next()
    {
        if (pos.x > -1000)
        {
            pos = slides.position;
            pos.x -= 620;
            slides.position = pos;
        }
    }
    public void Previous()
    {
        if (pos.x < 200)
        { 
            pos = slides.position;
            pos.x += 620;
            slides.position = pos;
        }
    }
}
