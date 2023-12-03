using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField, Range(0, 0.8f)] private float speed = 0.1f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        {
            transform.position = Vector3.Lerp(transform.position, offset + playerTransform.position, speed);
        }
    }
}
