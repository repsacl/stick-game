using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed = 25f;
  public int damage = 10;
  public Rigidbody2D rb;
  public GameObject impactEffect;

  public SpriteRenderer spriteRenderer;
  public TrailRenderer myTrailRenderer;

  void Start()
  {
    UpdateColor();
  }

  void UpdateColor()
  {
    myTrailRenderer.startColor = spriteRenderer.color;
    myTrailRenderer.endColor = spriteRenderer.color;
    impactEffect.GetComponent<ParticleSystem>().startColor = spriteRenderer.color;
    rb.linearVelocity = transform.right * speed;
  }

    //void OnTriggerEnter2D(Collider2D hitinfo)
    //{
      //  PlayerHealth pHealth = hitinfo.transform.GetComponent<PlayerHealth>();

        //if (pHealth != null)
        //{
          //pHealth.TakeDamage(damage);
        //}

        //Instantiate(impactEffect, transform.position, Quaternion.identity);
        //
        //
        //Balance balance = hitinfo.transform.GetComponent<Balance>();

        //if (balance != null)
        //{
        //  Instantiate(impactEffect, transform.position, Quaternion.identity);
        // Destroy(gameObject);
        //}

        //if (hitinfo.tag == "Player")
        //{

        //}
        //else
        //{
        //  Instantiate(impactEffect, transform.position, Quaternion.identity);
        //Destroy(this.gameObject);
        //}


        //Instantiate(impactEffect, transform.position, Quaternion.identity);
        //Destroy(this.gameObject);
    //}

    //void OnTriggerExit2D(Collider2D hitinfo)
    //{
      //  PlayerHealth pHealth = hitinfo.transform.GetComponent<PlayerHealth>();

        //if (pHealth != null)
        //{
          //  pHealth.TakeDamage(damage);
        //}

       // Instantiate(impactEffect, transform.position, Quaternion.identity);
        //Destroy(this.gameObject);
    //} 
    
    //void OnTriggerStay2D(Collider2D hitinfo)
    //{
      //  PlayerHealth pHealth = hitinfo.transform.GetComponent<PlayerHealth>();

        //if (pHealth != null)
        //{
          //  pHealth.TakeDamage(damage);
        //}

       /// Instantiate(impactEffect, transform.position, Quaternion.identity);
        //Destroy(this.gameObject);
    //}

  void OnCollisionEnter2D(Collision2D hitinfo)
  {
    PlayerHealth pHealth = hitinfo.transform.GetComponent<PlayerHealth>();

    if (pHealth != null)
    {
        pHealth.TakeDamage(damage);
    }

    Instantiate(impactEffect, transform.position, Quaternion.identity);
    Destroy(this.gameObject);
  }
}
