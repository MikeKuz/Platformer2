using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFirePoint : MonoBehaviour
{

    public Rigidbody2D player;
    public GameObject firePoin;
    [SerializeField] private bool front;
    private Transform basePosition;
    Vector2 vec;

    private void Awake()
    {
        basePosition = firePoin.transform;
        vec = new Vector2(basePosition.localPosition.x, basePosition.localPosition.y);
    }

    public void MirrorFirePoint(bool backwards)
    {
        int coef = -1;         
        Vector2 vec2 = new Vector2 (vec.x*coef, vec.y);            
        vec = vec2;            
        firePoin.transform.localPosition = vec;
    }
}
