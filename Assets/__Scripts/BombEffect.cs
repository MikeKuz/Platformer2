using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    public GameObject bombEffect;
    public GameObject go;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Instantiate(bombEffect, go.transform);
            Invoke("Remove", 0.5f);
        }
    }


    private void Remove()
    {
        Destroy(go);
    }
}
