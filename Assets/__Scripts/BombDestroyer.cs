using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroyer : MonoBehaviour
{
    public GameObject go;

    private void Start()
    {
        Invoke("Delete", 0.5f);

    }

    private void Delete()
    {
        Destroy(go);
    }
}
