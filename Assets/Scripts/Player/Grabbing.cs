using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grabbing : MonoBehaviour
{
    public GameObject hand;
    public LayerMask layertoGrab;

    public bool grabbing;
    bool hold = false;
    bool conected = false;

    public PlayerController pController;
    public ArmRotating shooting;

    private FixedJoint2D[] joint;

    void Start()
    {
        //pController = GetComponentInParent<PlayerController>();
    }

    public void Grab(InputAction.CallbackContext context)
    {
        if (context.performed && shooting.isShooting == false) //&& pController.haveGunPistol == false && pController.haveGunSniper == false && pController.haveGunAssultRifle == false)
        {
            hold = true;
            //hand.SetActive(true);
        }

        if (context.canceled && shooting.isShooting == false) //&& pController.haveGunPistol == false && pController.haveGunSniper == false && pController.haveGunAssultRifle == false)
        {
            hold = false;
            grabbing = false;
            joint = GetComponents<FixedJoint2D>();

            foreach (FixedJoint2D j in joint)
            {
                Destroy(j);
            }
            conected = false;

            //Destroy(GetComponent<FixedJoint2D>());
            //hand.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (hold) //&& col.gameObject.layer == layertoGrab)
        {
            Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
            if (rb != null && conected == false)
            {
                //BalanceRight.canRotate = false;
                FixedJoint2D fj = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                fj.connectedBody = rb;
                grabbing = true;
                conected = true;
            }
            else if(conected == false)
            {
                FixedJoint2D fj = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                grabbing = true;
                conected = true;
            }
        }
    }
}
