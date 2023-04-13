using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    string text;

    void Update()
    {
        text = PlayerPrefs.GetFloat("highscore").ToString("0");
        score.text = "Best score: " +text;
    }
}