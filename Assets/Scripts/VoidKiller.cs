using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidKiller : MonoBehaviour
{
    private int damage = 200;

    void OnCollisionEnter2D(Collision2D hitinfo)
    {
        PlayerHealth pHealth = hitinfo.transform.GetComponent<PlayerHealth>();

        if (pHealth != null)
        {
            pHealth.TakeDamage(damage);
        }
    }
}
