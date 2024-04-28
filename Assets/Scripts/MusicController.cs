using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Extensions;

public class MusicController : MonoBehaviour
{
    private AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = gameObject.GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("musicToggle"))
        {
            if(PlayerPrefs.GetString("musicToggle") != "0")
            {
                musicSource.enabled = true;
            }
            else
            {
                musicSource.enabled = false;
            }
        }
    }

    public void toggleMusic()
    {
        if(PlayerPrefs.GetString("musicToggle") != "0")
        {
            PlayerPrefs.SetString("musicToggle", "0");
            musicSource.enabled = false;
        }
        else {
            PlayerPrefs.SetString("musicToggle", "1");
            musicSource.enabled = true;
        
        }
    }

    
}
