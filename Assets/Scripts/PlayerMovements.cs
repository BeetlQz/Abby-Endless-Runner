using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private Transform FeetPosition;
    [SerializeField] private float GroundDistance = 0.25f;
    [SerializeField] private float GrindTop = 0.6f;
    [SerializeField] private float JumpTime = 0.3f;
    [SerializeField] private Animator animator;

    [SerializeField] public float BoostForce = 7f;
    [SerializeField] private float BoostTime = 0.3f;

    private bool isBoosting = false;
    private float BoostTimer;

    private bool isGrounded = false;
    private bool IsJumping = false;
    private float JumpTimer;
    private bool isGrinding = false;


    private void Update()
    {
        
        if (Physics2D.OverlapCircle(FeetPosition.position, GroundDistance, GroundLayer) == true)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            //animator.SetBool("IsJumping", false);
        }

        if (Physics2D.OverlapCircle(FeetPosition.position, GrindTop, GroundLayer) == true)
        {
            isGrounded = true;
            isGrinding = true;

        }
        else
        {
            isGrounded= false;
            isGrinding= false;
        }

        // isGrounded = Physics2D.OverlapCircle(feetPosition.position, GroundDistance, GroundLayer);

        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            playerRigidbody.velocity = Vector2.up * JumpForce;
            IsJumping = true;
            Debug.Log(isGrounded);
            //animator.SetBool("IsJumping", true);
        }

        if(IsJumping && Input.GetButton("Jump"))
        {
            if(JumpTimer < JumpTime)
            {
                playerRigidbody.velocity = Vector2.up * JumpForce;

                JumpTimer += Time.deltaTime;
            }
            else
            {
                 IsJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            IsJumping = false;
            JumpTimer = 0f;
        }
       
    }

   /* public void UpdateBatteryAmount(PlayerInventory playerInventory)
    {

        if (Input.GetKeyDown("w"))
        {
            playerRigidbody.velocity = Vector2.right * BoostForce;
            isBoosting = true;
        }

        if (isBoosting && Input.GetKey("w"))
        {
            if (BoostTimer < BoostTime)
            {
                playerRigidbody.velocity = Vector2.right * BoostForce;

                BoostTimer += Time.deltaTime;
            }
            else
            {
                isBoosting = false;
            }
        }

        if (Input.GetKeyUp("w"))
        {
            isBoosting = false;
            BoostTimer = 0f;
        }

    } */
}
