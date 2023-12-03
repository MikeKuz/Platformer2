using Platformer2.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField, Range(0.1f, 1f)] private float shootingAnimationTime;
    private bool isShooting;
    private Animator animator;
    private SpriteRenderer sr;
    public bool backwards = false;
    public PlayerMovement playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }

    public void Shoot(float direction)
    {
        isShooting = true;
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        backwards = playerMovement.Backwards;

        if (!backwards)
        {
            currentBulletVelocity.velocity = new Vector2(fireSpeed*1, currentBulletVelocity.velocity.y);
            ChangeAnimationOnShoot(isShooting, false);

        }

        

        else
        {
            
            currentBulletVelocity.velocity = new Vector2(fireSpeed*(-1), currentBulletVelocity.velocity.y);
            ChangeAnimationOnShoot(isShooting, true);

        }

    }

    private void ChangeAnimationOnShoot(bool isShooting, bool mirrored)
    {
        sr.flipX = mirrored;
        animator.SetBool("isShooting", isShooting);
        Invoke(nameof(ChangeAnimationOnNotShoot), shootingAnimationTime);
    }


    private void ChangeAnimationOnNotShoot()
    {
        isShooting = false;
        animator.SetBool("isShooting", isShooting);
    }
}
