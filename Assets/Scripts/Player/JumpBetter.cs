using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpBetter : MonoBehaviour
{
    public Animator anim;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float forceDown = 5.5f;

    public Rigidbody2D rb;
    public bool pressedd;
    public bool isFalling = false;
    public bool Isdown = false;

    public Grabbing grabL;
    public Grabbing grabR;

    PlayerController pc;

    void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (pc.isGrounded == false && rb.linearVelocity.y < 0 && grabL.grabbing == false && grabR.grabbing == false)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            isFalling = true;
        }
        else if (rb.linearVelocity.y > 0 && pressedd == false && pc.isGrounded == false && grabL.grabbing == false && grabR.grabbing == false)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //if (pc.isGrounded == true)
        //{
            //isFalling = false;
        //}

        if (pc.isGrounded == true && isFalling == true)
        {
            FindObjectOfType<AudioManager>().Play("JumpLandStep");
            isFalling = false;
        }

        if (Isdown == true && grabL.grabbing == false && grabR.grabbing == false) //pc.isGrounded == false)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (forceDown - 1) * Time.deltaTime;
        }

        //falling();
    }

    void falling()
    {
        if (isFalling == true)
        {
            anim.SetTrigger("isJumping");
            anim.SetBool("IsJumping", true);
        }
    }

    public void pressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pressedd = true;
        }
        if (context.canceled)
        {
            pressedd = false;
        }
    }

    public void down(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Isdown = true;
        }
        if (context.canceled)
        {
            Isdown = false;
        }
    }
}
