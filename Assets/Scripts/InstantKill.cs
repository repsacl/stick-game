using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private int damage = 200;

    void OnCollisionEnter2D(Collision2D hitinfo)
    {
        PlayerHealth pHealth = hitinfo.transform.GetComponent<PlayerHealth>();

        if (pHealth != null)
        {
            pHealth.TakeDamage(damage);
            FindObjectOfType<AudioManager>().Play("Bullet");
        }
    }
}
