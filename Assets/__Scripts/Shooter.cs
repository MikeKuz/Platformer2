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
    private bool _isShooting;
    private Aim aim;

    //private Animator animator;
    public AnimationChanger animatorChanger;
    private SpriteRenderer sr;
    public bool backwards = false;
    public PlayerMovement playerMovement;
    [SerializeField] private bool gunIsLoaded;
    [SerializeField, Range(0.1f, 3f)] private float reloadTime; //Время между выстрелами
    [SerializeField]private float timeToReload; //Время до перезарадки
    [SerializeField] private float currentTime;  //Текущее время до перезарядки

    public bool isShooting 
    { get { 
            return _isShooting; 
        } 
        set { 
            if(value==true)
            {
                _isShooting=value;
            }
            else
            {
                animatorChanger.NotShooting();
                _isShooting = value;
            }
        } 
    }

    private void Update()
    {
        if (gunIsLoaded==false)
        {
            if (timeToReload < -1)
            {
                timeToReload = reloadTime;

            }
            else
            {
                timeToReload -= Time.deltaTime;
            }

            if (timeToReload <= 0)
            {
                gunIsLoaded = true;
                timeToReload = -2;
            }
        }
    }

    private void Awake()
    {
        aim = GetComponent<Aim>();
        animatorChanger = GetComponent<AnimationChanger>();
        //animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }

    public void Shoot()
    {
        if(gunIsLoaded)
        {
            Vector2 directionFromPlayerToAim = new Vector2(aim.directionFromPlayerToAim.x, aim.directionFromPlayerToAim.y);
            
            gunIsLoaded=false;
            GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
            currentBulletVelocity.velocity = directionFromPlayerToAim.normalized * fireSpeed;

            ChangeAnimation(reloadTime);
        }
    }


    private void ChangeAnimation(float reloadTime)
    {
        animatorChanger.IsShooting(reloadTime);

    }

    //private void ChangeAnimationOnShoot(bool isShooting, bool mirrored)
    //{
    //    sr.flipX = mirrored;
    //    //animator.SetBool("isShooting", isShooting);
    //    Invoke(nameof(ChangeAnimationOnNotShoot), shootingAnimationTime);
    //}


    //private void ChangeAnimationOnNotShoot()
    //{
    //    _isShooting = false;
    //    //animator.SetBool("isShooting", isShooting);
    //}
}
