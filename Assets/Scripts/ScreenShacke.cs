using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShacke : MonoBehaviour
{
    public Animator anim;

    public void CamShacke()
    {
        int rand = Random.Range(0, 3);

        if (rand == 0)
        {
            anim.SetTrigger("shacke1");
        }

        if (rand == 1)
        {
            anim.SetTrigger("shacke2");
        }

        if (rand == 2)
        {
            anim.SetTrigger("shacke3");
        }

        if (rand == 2)
        {
            anim.SetTrigger("shacke3");
        }
    }
}
