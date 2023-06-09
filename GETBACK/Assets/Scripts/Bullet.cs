using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 20;

  
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy Enemy = collision.gameObject.GetComponent<enemy>();

        if (Enemy != null)
        {
            Enemy.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}