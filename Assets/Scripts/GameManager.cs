using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public MulitpleCamerafollow camerafollow;
    public Animator doorAnimator;

    public float timeStart;
    private float minuts, seconds, milliseconds;
    public float timeDown = 10;

    public TextMeshProUGUI textTimer;
    public GameObject TextTimer;
    public TextMeshProUGUI textCountDown;

    public bool canTime = false;
    public bool countDown = false;
    public bool startedGame = false;

    public GameObject wall;
    public GameObject countDownText;

    public bool readTime = false;

    public GameObject inputManager;

    public float timeTest;

    void Start()
    {
        TextTimer.SetActive(false);
        camerafollow.enabled  = false;
        textCountDown.text = timeDown.ToString();
    }

    void Update()
    {
        if (canTime == true)
        {
            //minuts = (int)(timeStart / 60);
            //seconds = (int)(timeStart % 60);
            //milliseconds = (int)(timeStart * 100);
            //timeStart += Time.deltaTime;

            //textTimer.text = minuts.ToString("00") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("0");

            timeStart += Time.deltaTime;
            milliseconds = (int)((timeStart-(int)timeStart)*100);
            seconds = (int)(timeStart % 60);
            minuts = (int)(timeStart / 60 % 60);

            textTimer.text = string.Format("{0:00}:{1:00}:{2:00}",minuts,seconds,milliseconds);

        }

        if(readTime == true)
        {
            canTime = false;
            textTimer.text = timeStart.ToString();
        }

        if (timeDown <= 0)
        {
            StartGame();
            countDown = false;
        }

        if (countDown == true)
        {
            timeDown -= Time.deltaTime;
            textCountDown.text = Mathf.Round(timeDown).ToString();
        }
    }

    public void CountDown()
    {
        countDown = true;
    }

    public void StartGame()
    {
        //wall.SetActive(false);
        startedGame = true;
        doorAnimator.SetTrigger("DoorTrigger");
        countDownText.SetActive(false);
        canTime = true;
        camerafollow.enabled  = true;
        TextTimer.SetActive(true);
        inputManager.SetActive(false);
    }

    public void DoorPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            countDown = true;
        }
    }
}
