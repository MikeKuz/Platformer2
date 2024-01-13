using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChanger : MonoBehaviour
{

    public Animator animator;

    public bool isGrounded;
    public bool isJump;
    public bool isRun;
    public bool isDead;
    private bool isShooting;
    [SerializeField]private bool _backwards;
    [SerializeField]private SpriteRenderer sr;


    public bool backwards { get { return _backwards;  } 
        set { 
                if(_backwards != value)
                {
                    _backwards = value; ReflectSprite(); 
                }
                else { }
            }
            
        
    }

    private void ReflectSprite()
    {
        sr.flipX = backwards;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }



    private void Update()
    {

    }
    public void Jump()
    {
        animator.SetBool("isGrounded", isGrounded);
        //SendMessage("Jump");
    }
    public void ChangeJumpAnimation(bool isGround)
    {
        if(isGround)
        {
            Jump();
        }
        else
        {
            PlayerOnGround();
        }
    }

    public void PlayerOnGround()
    {
        animator.SetBool("isGrounded", isGrounded);
        //SendMessage("PlayerOnGround");
    }

    public void IsShooting(float reloadTime)
    {
        isShooting = true;
        animator.SetBool("isShooting", true);
        //Invoke("NotShooting", reloadTime);
    }
    


    public void NotShooting()
    {
        isShooting = false;
        animator.SetBool("isShooting", false);
    }

    public void IsRun()
    {
        isRun=true;
        animator.SetBool("isRun", true);
    }

    public void NotRun()
    {
        isRun = false;
        animator.SetBool("isRun", false);

    }

    private new void SendMessage(string message)
    {
        Debug.Log("AnimationChanger "+message);
    }
}
