using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public GameObject EndGameCanvas;
    
    [Space]
    
    public List<int> PlayerID = new List<int>(); //{1, 3, 3, 4, 5};
    
    [Space]
    
    public List<PlayerUIIDManager> pIDManager = new List<PlayerUIIDManager>();
    
    [Space]
    
    public List<float> playerTime = new List<float>();
    
    [Space]
    
    public List<TextMeshProUGUI> timeText = new List<TextMeshProUGUI>();
    
    public GameManager gameManager;

    public PlayerTimeID[] playerTimeIds;

    void Start()
    {
        EndGameCanvas.GetComponent<Canvas>().enabled = false;
        gameManager = transform.GetComponent<GameManager>();
        //playerObje = GameObject.FindGameObjectsWithTag("PlayerObj");
        //pIDManager = GameObject.FindGameObjectWithTag("PlayerObj").GetComponents<PlayerUIIDManager>();
        
    }

    void Update()
    {  
        if(gameManager.countDown == false)
        {
            
        }

        //timeText.text = "P" + PlayerID.Count + ":" + playerTime;
        //timeTextTest();
    }

    void TimeTextTest(int playerID)
    {
        //for (int i = 0; i < timeText.Count; i++)
        //{
            //for (int j = 0; j < PlayerID[j]; j++)
           // {
               // timeText[i].text = "P" + PlayerID[j] + " " + playerTime[j];
            //}
        //}

        foreach (TextMeshProUGUI t in timeText)
        {
            for (int j = 0; j < PlayerID.Count; j++)
            {
                timeText[j].text = "1.  P" + PlayerID[j] + " " + playerTime[j];
            }
        }
    }

    public void Goal(int playerId)
    {
        EndGameCanvas.GetComponent<Canvas>().enabled = true;
        TimeTextTest(playerId);
    }
}
