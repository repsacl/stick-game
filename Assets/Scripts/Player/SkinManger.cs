using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkinManger : MonoBehaviour
{
    public GameObject playerObject;
    public SpriteRenderer sr;
    public List<Color> skinsColor = new List<Color>();
    int selectedSkin = 0;
    public GameObject playerSkin;

    void Start()
    {

    }

    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if (selectedSkin == skinsColor.Count)
        {
            selectedSkin = 0;
        }

        SpriteRenderer[] renderers = playerObject.GetComponentsInChildren<SpriteRenderer>();
        //sr.color = skinsColor[selectedSkin];

        foreach (SpriteRenderer rd in renderers)
        {
            rd.color = skinsColor[selectedSkin];
        }
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin < 0)
        {
            selectedSkin = skinsColor.Count - 1;
        }

        SpriteRenderer[] renderers = playerObject.GetComponentsInChildren<SpriteRenderer>();
        //sr.color = skinsColor[selectedSkin];

        foreach (SpriteRenderer rd in renderers)
        {
            rd.color = skinsColor[selectedSkin];
        }
    }

    public void PlayGame()
    {
        //PrefabUtility.SaveAsPrefabAsset(playerSkin, "Assets/Prefabs/Players/P1.prefab");
    }
}
