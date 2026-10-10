using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public string tag;

    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = transform.GetComponent<Collider2D>();

        if (col.collider.tag == tag)
        {
            Physics2D.IgnoreCollision(collider, col.collider);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        Collider2D collider = transform.GetComponent<Collider2D>();

        if (col.collider.tag == tag)
        {
            Physics2D.IgnoreCollision(collider, col.collider);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Collider2D collider = transform.GetComponent<Collider2D>();

        if (col.collider.tag == tag)
        {
            Physics2D.IgnoreCollision(collider, col.collider);
        }
    }
}
