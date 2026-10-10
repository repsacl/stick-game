using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public string collisionTag;

    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col){

        GameObject playerObject = col.gameObject;
        PlayerController pController = col.transform.GetComponent<PlayerController>();

        if(playerObject.tag == collisionTag && pController != null){

            pController.camFollow.targets.Remove(playerObject.GetComponent<Transform>());

            Destroy(playerObject);
        }
    }
}
