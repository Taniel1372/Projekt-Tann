using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(6.589f,transform.eulerAngles.y,0);
    }
}
