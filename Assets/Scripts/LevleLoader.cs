using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class LevleLoader : MonoBehaviour
{
    public Animator anim;
    public float transisionTime = 1f;

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(levelLoad(sceneName));
    }

    IEnumerator levelLoad (string sceneName)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transisionTime);
        
        SceneManager.LoadScene(sceneName);
    }
}
