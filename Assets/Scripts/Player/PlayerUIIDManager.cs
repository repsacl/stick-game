using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerUIIDManager : MonoBehaviour
{
    public int playerID;
    public TextMeshProUGUI playerText;
    public GameObject IDholder;

    public float playerTime;
    
    private GameManager gameManager;
    private TimeManager timeManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        timeManager = FindObjectOfType<TimeManager>();

        playerID = GetComponent<PlayerInput>().playerIndex + 1;
        playerText.text = "P" + playerID;
        
        timeManager.PlayerID.Add(playerID);
    }

    public void PlayerID()
    {
        IDholder.SetActive(false);
    }

    void Update ()
    {
        if(gameManager.countDown == true)
        {
            PlayerID();
        }
    }
}
