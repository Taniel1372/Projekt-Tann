using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public string scenename;
    public void MapChosen()
    {
        SceneManager.LoadScene(scenename);
    }
}