using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemyDamage = 10f;
    [SerializeField] private float _pushPower = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            MakeDamage(collision);
            Vector2 direction = CheckDirectionPush(collision);
            collision.rigidbody.velocity = direction;
            GetComponent<Health>().TakeDamage(10);
        }
    }

    private Vector2 CheckDirectionPush(Collision2D collision)
    {
        Transform target = collision.gameObject.transform;
        Transform startPosition = gameObject.transform;

        return new Vector2(target.position.x - startPosition.position.x, 1f).normalized * _pushPower;
    }

    private void MakeDamage(Collision2D collision)
    {
        collision.gameObject.GetComponent<Health>().TakeDamage(_enemyDamage);
    }
}
