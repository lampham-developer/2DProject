using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{

    public CharacterController2D controller;
    public float horizontalMove = 0f;
    public float runSpeed = 1000f;

    bool isJumping = false;
    bool isCrouching = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        

        if(Input.GetButtonDown("Jump")){
            isJumping = true;
            animator.SetBool("isJumping", true);
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

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData) { }
}
