using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmRotating : MonoBehaviour
{
    [Header("Rotation controller")]
    public float tagetRotation;
    public Rigidbody2D rb;
    public float force;
    //public bool m_FacingRight = true;

    public Vector2 rotateTarget;
    public float mousePosition;

    public bool isRotating = false;
    public bool canRotate = true;
    public bool isShooting = true;

    public PlayerController pController;

    public Camera camera;

    void Start()
    {
        //camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //pController = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        rotating();

        mousePosition = Mathf.Atan2(rotateTarget.y, rotateTarget.x) * Mathf.Rad2Deg;

        if (isRotating == true && isShooting == true) //&& canRotate) // && PlayerController.haveGunPistol == false)
        {
            //rb.MoveRotation(mousePosition);
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, mousePosition, force * Time.fixedDeltaTime));
        }

        if (isRotating == true && isShooting == false && canRotate == true) //&& canRotate) // && PlayerController.haveGunPistol == false)
        {
            //rb.MoveRotation(mousePosition);
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, mousePosition, force * Time.fixedDeltaTime));
        }
    }

    void rotating()
    {
        if (rotateTarget.x == 0)
        {
            isRotating = false;
        }

        if (rotateTarget.x > 0)
        {
            isRotating = true;
        }

        if (rotateTarget.y == 0)
        {
            isRotating = false;
        }

        if (rotateTarget.y > 0)
        {
            isRotating = true;
        }
    }

    public void RrotateArm(InputAction.CallbackContext context)
    {
        rotateTarget = context.ReadValue<Vector2>();
        //rotateTarget = camera.ScreenToWorldPoint (context.ReadValue<Vector2>());
    }

    public void CanRotate(InputAction.CallbackContext context)
    {
        if (context.performed) // && pController.haveGunPistol == false && pController.haveGunAssultRifle == false && pController.haveGunSniper == false)
        {
            canRotate = true;
        }
        if (context.canceled) // && pController.haveGunPistol == false && pController.haveGunAssultRifle == false && pController.haveGunSniper == false)
        {
            canRotate = false;
        }
    }
}
