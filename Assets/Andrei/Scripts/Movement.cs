using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
/*
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private readonly float playerSpeed = 15.0f;
    private Vector3 playerPosition;
    private Animator anim;

    public Vector3 PlayerPosition => playerPosition;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector3 move = new Vector3(input.x, 0, input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        playerPosition = gameObject.transform.position;

        if (input.x > 0 || (input.x == 0 && input.y > 0))
        {
            anim.SetBool("IsRunningRight", true);
            anim.SetBool("IsRunningLeft", false);
        }
        else if (input.x < 0 || (input.x == 0 && input.y < 0))
        {
            anim.SetBool("IsRunningRight", false);
            anim.SetBool("IsRunningLeft", true);
        }
        else
        {
            anim.SetBool("IsRunningRight", false);
            anim.SetBool("IsRunningLeft", false);
        }
    }*/
}
