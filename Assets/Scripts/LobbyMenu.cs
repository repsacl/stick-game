using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LobbyMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    //LobbyMenu PauseMenu;

    public bool paused = false;

    Canvas pauseComponent;


    void Start()
    {
        pauseMenu = GameObject.Find("CanvasPauseMenu"); //.GetComponent<GameObject>() as GameObject;
        //pauseMenu.Add(GetComponent<GameObject>() as GameObject);
        pauseComponent = pauseMenu.GetComponent<Canvas>();
    }

    public void Pause()
    {
        //pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        pauseComponent.enabled = true;
        Time.timeScale = 0f;
        paused = true;
    }

    public void ReusmeGame()
    {
        //pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        pauseComponent.enabled = false;
        Time.timeScale = 1f;
        paused = false;
    }

    public void PausePress(InputAction.CallbackContext context)
    {
        if (context.performed && paused == true)
        {
            ReusmeGame();
        }
        else if(context.performed)
        {
            Pause();
        }
    }
}
