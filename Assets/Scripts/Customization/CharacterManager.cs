using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    public PlayerController pController;
    public CharcterDatabase charcterDB;

    public Sprite artworkSprite;

    public bool canSwitch = true;

    private static int selectedOption = 0;

    GameManager gameManager;

    void Start()
    {
        //if (PlayerPrefs.HasKey("selectedOption"))
        //{
            //selectedOption = 0;
        //}
        //else
        //{
            //Load();
        //}

        //UpdtatedCharacter(selectedOption);

        gameManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
    }

    void Update ()
    {
        if(gameManager.startedGame == true)
        {
            canSwitch = false;
        }
    }

    public void NextOption(InputAction.CallbackContext context)
    {
        if(context.performed && canSwitch == true)
        {

            selectedOption++;

            if (selectedOption >= charcterDB.CharacterCount)
            {
                selectedOption = 0;
            }

            UpdtatedCharacter(selectedOption);
            Save();
        }

    }

    public void BackOption(InputAction.CallbackContext context)
    {
        if(context.performed && canSwitch == true)
        {
            
            selectedOption--;

            if (selectedOption < 0)
            {
                selectedOption = charcterDB.CharacterCount - 1;
            }

            UpdtatedCharacter(selectedOption);
            Save();
        }
    }

    private void UpdtatedCharacter(int selectedOption)
    {
        Character character = charcterDB.GetCharacter(selectedOption);
        //artworkSprite.color = character.playerColor;

        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer rd in renderers)
        {
            rd.color = character.playerColor;
            pController.playerColor = rd.color;
            pController.trailRenderer.startColor = rd.color;
        }
    }

    private static void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private static void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
