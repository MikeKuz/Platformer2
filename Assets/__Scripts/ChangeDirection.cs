using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    
    SliderJoint2D sliderJoint;
    float reverse  = -1f;
    JointMotor2D motor;

    private void Awake()
    {
        sliderJoint=GetComponent<SliderJoint2D>();
        
        motor = sliderJoint.motor;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("limiter"))
        {
            motor.motorSpeed *= reverse;
            sliderJoint.motor = motor;
        }
    }



}
