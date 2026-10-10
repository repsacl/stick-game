using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void PlayMap1()
    {
        FindObjectOfType<LevleLoader>().LoadLevel("Map1");
    }

    public void PlayMap2()
    {

    }

    public void PlayMap3()
    {

    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Click()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void ButtonHover()
    {
        FindObjectOfType<AudioManager>().Play("ButtonHover");
    }
}
