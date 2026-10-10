using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;

    //LobbyMenu PauseMenu;

    public bool paused = false;

    Canvas pauseComponent;


    void Awake()
    {
        //pauseMenu = GameObject.Find("CanvasPauseMenu/PausMenu"); //.GetComponent<GameObject>() as GameObject;
        //pauseMenu.Add(GetComponent<GameObject>() as GameObject);

        //pauseMenu.SetActive(false);

        pauseComponent = transform.GetComponent<Canvas>();
        pauseComponent.enabled = false;
    }

    public void MoveSelected()
    {
        FindObjectOfType<AudioManager>().Play("ButtonHover");
    }

    public void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        //pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        pauseComponent.enabled = true;
        Time.timeScale = 0f;
        paused = true;
    }

    public void ReusmeGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        //pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        pauseComponent.enabled = false;
        Time.timeScale = 1f;
        paused = false;
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        //pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        FindObjectOfType<AudioManager>().Play("Click");
        pauseComponent.enabled = false;
        Time.timeScale = 1f;
        paused = false;
        FindObjectOfType<LevleLoader>().LoadLevel("Menu");
    }

    void Update()
    {
        if(pauseComponent.enabled == false)
        {
            pauseMenu.SetActive(false);
        }

        if(pauseComponent.enabled == true)
        {
            pauseMenu.SetActive(true);
        }
    }
}
