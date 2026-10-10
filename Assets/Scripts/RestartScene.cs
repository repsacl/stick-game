using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RestartScene : MonoBehaviour
{
    public void RestartSc(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RestartS();
        }
    }

    void RestartS()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
