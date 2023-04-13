using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public AudioSource Track1;
    public AudioSource Track2;
    public AudioSource Track3;

    public int trackHistory;
    public int Track;
    // Start is called before the first frame update
    void Start()
    {
        Track = Random.Range(0,3);
        if (Track == 0)
        {
            Track1.Play();
            trackHistory = 1;
        }
        else if (Track == 1)
        {
            Track2.Play();
            trackHistory = 2;
        }
        else if (Track == 2)
        {
            Track3.Play();
            trackHistory = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Track1.isPlaying == false && Track2.isPlaying == false && Track3.isPlaying == false)
        {
            Track = Random.Range(0,3);
            if (Track == 0 && trackHistory != 1)
            {
                Track1.Play();
                trackHistory = 1;
            }
            else if (Track == 1 && trackHistory != 2)
            {
                Track2.Play();
                trackHistory = 2;
            }
            else if (Track == 2 && trackHistory != 3)
            {
                Track3.Play();
                trackHistory = 3;
            }
        }
    }
}
