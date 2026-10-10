using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject pickupEffeck;

    public float multiplier = 1.2f;
    public float duration = 3f;

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if(hitinfo.CompareTag("PowerUp"))
        {
            StartCoroutine(PickUp(hitinfo));
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        FindObjectOfType<AudioManager>().Play("PowerUp");
        Instantiate(pickupEffeck, transform.position, transform.rotation);

        PlayerController playerController = GetComponent<PlayerController>();

        playerController.playerSpeed *= multiplier;

        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        playerController.playerSpeed /= multiplier;

        Destroy(player);
    }
}
