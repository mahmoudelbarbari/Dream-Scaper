using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovementscript : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    // Start is called before the first frame update
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;

        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }
    public void Onlanding()
    {
        animator.SetBool("IsJumping", false);
    }
    private void FixedUpdate()
    {
        //Move Alora
         controller.Move(horizontalMove*Time.fixedDeltaTime,false,jump);
         jump = false;
    }

}
