using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollecktacble : MonoBehaviour
{
    public int ammoToAdd;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //GameObject colGO = col.gameObject;
        //if(colGO.name == "PlayerAmmoArm")
        //{
          //  colGO.GetComponent<Shooting>().UpdateAmmo(ammoToAdd);
            //Destroy(gameObject);
        //}

        Shooting shooting = col.transform.GetComponent<Shooting>();

        if(shooting != null)
        {
            shooting.UpdateAmmo(ammoToAdd);
            Destroy(gameObject);
        }
    }
}
