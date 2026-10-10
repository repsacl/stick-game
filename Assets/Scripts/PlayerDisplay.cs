using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    public PlayerObject player;

    [Space]

    [Header("Customization Sprite Color")]
    public SpriteRenderer hat;
    public Color hatColor;

    void Start()
    {
        Debug.Log(player.name);

        hat.sprite = player.hat;

        PlayerColor();
        hat.color = hatColor;
    }

    void PlayerColor()
    {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer rd in renderers)
        {
            rd.color = player.playerColor;
        }
    }
}
