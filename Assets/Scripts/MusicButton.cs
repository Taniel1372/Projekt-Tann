using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicButton : MonoBehaviour
{
    bool music;
    public AudioSource musicPlayer;
    public TextMeshProUGUI musictext;
    public void Music()
    {
        if (music)
        {
            music = false;
		    musictext.text = "Music: Off";
            musicPlayer.mute = true;
        }
        else if (!music)
        {
            music = true;
		    musictext.text = "Music: On";
            musicPlayer.mute = false;
        }
    }
}
