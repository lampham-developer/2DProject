using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour
{

    public static PlayerMovementScript PlayerMovementSingleton;
    public CharacterController2D controller;
    public float horizontalMove = 0f;
    static float runSpeed = 250f;

    bool isJumping = false;
    bool isCrouching = false;
    public Animator animator;

    public bool isMovingLeft = false;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementSingleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        moveByButton();

        if(Input.GetButtonDown("Jump")){
            jump();
        }

        if(Input.GetButtonDown("Crouch")){
            isCrouching = true;
            animator.SetBool("isCrouching", isCrouching);
        }else if(Input.GetButtonUp("Crouch")){
            isCrouching = false;
            animator.SetBool("isCrouching", isCrouching);
        }
    }

//move the character
    void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        isJumping = false;
    }

    public void OnCrouching(bool crouching)
    {
        animator.SetBool("isCrouching", crouching);
    }

    public void moveByButton(){
        if(isMovingLeft && isMoving) horizontalMove = -1 * runSpeed;
        else if((!isMovingLeft && isMoving)) horizontalMove =  runSpeed;
    }

    public void moveLeft(){
        isMoving = true;
        isMovingLeft = true;
    }

    public void moveRight(){
        isMoving = true;
        isMovingLeft =  false;
    }

    public void cancelMove(){
        isMoving = false;
        horizontalMove = 0f;
    } 

    public void jump(){
        isJumping = true;
            animator.SetBool("isJumping", true);
    }
}
