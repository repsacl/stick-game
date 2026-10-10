using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public float fireRate = 0.3f;
    float nextFire = 0.0f;
    bool shooting = false;
    public float bulletSpeed;
    public int damage;
    public int maxAmmo;
    private int currrentAmmo;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    public GameObject bullet;

    public float recoilUp = 80f;
    public float knockBack = 850f;
    public Rigidbody2D rb;
    public Rigidbody2D rbBody;
    public GameObject armT;

    //public GameObject flipGun;

    //public bool m_FacingRight = true;

    //public Vector2 rotateTarget;
    //public float mousePosition;

    //public bool isRotating = false;

    public PlayerController pController;

    //[System.NonSerialized]
    [HideInInspector]
    public GameObject bulletClone; //= bullet;'

    void Start() 
    {
        currrentAmmo = maxAmmo;
    }

    void Update()
    {
        if (shooting == true && Time.time > nextFire && currrentAmmo > 0)
        {
            nextFire = Time.time + fireRate;
            shoot();
            UpdateAmmo(-1);
        }

        //if ((mousePosition >= 0.0f && mousePosition <= 90.0f) || (mousePosition <= 0.0f && mousePosition >= -70.0f))
        //{
          //  Vector3 thescale = flipGun.transform.localScale;
            //if (!m_FacingRight) FlipGun();

        //}
        //else if ((mousePosition > 90.0f && mousePosition <= 180.0f) || (mousePosition < -110.0f && mousePosition > -180f))
        //{
          //  ((if (m_FacingRight) FlipGun();

        //}
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time > nextFire)
        {
            shooting = true;
        }

        if (context.canceled)
        {
            shooting = false;
        }
    }

    void shoot()
    {
        //SpriteRenderer colorbullet = bullet.GetComponent<SpriteRenderer>();
        //colorbullet.color = pController.playerColor;

        //var bulletScript = bullet.GetComponent<Bullet>();
        //bulletScript.damage = damage;
        //bulletScript.speed = bulletSpeed;
        BulletData();

        Instantiate(bullet, firePoint.position, firePoint.rotation);

        Vector2 dir = armT.transform.position - transform.position;
        dir.y = 0;

        rbBody.AddForce(dir.normalized * knockBack);
        rb.AddForce(Vector2.up * recoilUp);
    }

    //private void FlipGun()
    //{
      //  m_FacingRight = !m_FacingRight;
        //Vector3 thescale = flipGun.transform.localScale;
        //thescale.y = -thescale.y;
        //flipGun.transform.localScale = thescale;
    //}

    void BulletData()
    {
        SpriteRenderer colorbullet = bullet.GetComponent<SpriteRenderer>();
        colorbullet.color = pController.playerColor;

        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.damage = damage;
        bulletScript.speed = bulletSpeed;
    }

    public void UpdateAmmo(int ammo)
    {
        currrentAmmo += ammo;

        if(currrentAmmo > maxAmmo)
        {
            currrentAmmo = maxAmmo;
        }
    }
}
