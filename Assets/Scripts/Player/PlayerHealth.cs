using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController playerC;
    private ScreenShacke shacke;

    [Header("Health")]
    private static int currentHealth;
    public int maxHealth = 200;

    [Header("Healthbar Controller")]
    public GameObject Healtbar;
    public HealthBar healthBar;
    public float secondsHealthShown = 1f;

    [Header("Effect")]
    public GameObject deathEffect;
    public GameObject playerBlood;
    private TrailRenderer trailRenderer;

    [Header("Respawn Controller")]
    public GameObject player;
    public float secondsWaitSpawn = 0.2f;

    public GameObject head;

    //bool takingDamage = false;

    private float orgR;
    private float orgG;
    private float orgB;
    private float orgA;

    void Start()
    {
        playerC = player.transform.GetComponent<PlayerController>();
        trailRenderer = head.transform.GetComponent<TrailRenderer>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Healtbar.SetActive(true);

        colorEffect();

        shacke = GameObject.FindGameObjectWithTag("shacke").GetComponent<ScreenShacke>();
    }

    public void colorEffect()
    {
        orgR = playerC.playerColor.r;
        orgG = playerC.playerColor.g;
        orgB = playerC.playerColor.b;
        orgA = playerC.playerColor.a;

        playerBlood.GetComponent<ParticleSystem>().startColor = new Color(orgR, orgG, orgB, orgA);
        deathEffect.GetComponent<ParticleSystem>().startColor = new Color(orgR, orgG, orgB, orgA);
        //trailRenderer.startColor = new Color(orgR, orgG, orgB, orgA);
    }

    void Update()
    {
        //if (takingDamage == true)
        //{
        //  Healtbar.SetActive(true);
        //}
        //else if (takingDamage == false)
        //{
        //  StartCoroutine(ShowHealthbar());
        //}

        //if (takingDamage == false)
        //{
        //  Healtbar.SetActive(false);
        //}
    }

    public void TakeDamage(int damage)
    {
        colorEffect();
        //takingDamage = true;
        //StartCoroutine(ShowHealthbar());
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        Instantiate(playerBlood, transform.position, Quaternion.identity);

        if (currentHealth <= 0)
        {
            //Die();
            StartCoroutine(DieE());
        }

        //takingDamage = false;
    }

    IEnumerator ShowHealthbar()
    {
        Healtbar.SetActive(true);
        yield return new WaitForSeconds(secondsHealthShown);
        Healtbar.SetActive(false);
        //takingDamage = false;
    }

    public IEnumerator DieE()
    {
        colorEffect();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        shacke.CamShacke();
        //player.SetActive(false);

        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        yield return new WaitForSeconds(secondsWaitSpawn);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player.transform.position = playerC.respawnPoint;
        FindObjectOfType<AudioManager>().Play("Respawn");
        //player.SetActive(true);
        Instantiate(playerBlood, transform.position, Quaternion.identity);
    }

    void active(bool act)
    {
        player.SetActive(act);
    }

    void Die()
    {
        colorEffect();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        shacke.CamShacke();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        player.transform.position = playerC.respawnPoint;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //dead = true;
    }
}
