using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{

    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;

    private int layerCount;

    private void Start()
    {
        layerCount = layers.Length;
    }

    void Update()
    {
        for(int i = 0; i<layerCount; i++)
        {
            
            layers[i].position = new Vector2(transform.position.x * coeff[i], transform.position.y * coeff[i]);
        }
    }
}
