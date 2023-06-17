using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float movementSpeed;
    public float originalSpeed;

    public float slowAmount = 1f;
    public float slowDuration = 2f;

    public GameObject bloodSplatter;
    public GameObject bloodExplosion;
    private void Start()
    {
        currentHealth = maxHealth;
        originalSpeed = movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ApplySlow(slowAmount);
            StartCoroutine (ResetSpeed());
        }
    }


    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
            Instantiate(bloodSplatter, transform.position, Quaternion.identity);
            Instantiate(bloodExplosion, transform.position, Quaternion.identity);

        }
    }


    private void Die()
    {
        // Handle enemy death, such as playing death animation, awarding points, etc.
        Destroy(gameObject);
    }


    public void ApplySlow(float slowAmount)
    {
        movementSpeed = originalSpeed - slowAmount;
    }


    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(slowDuration);
        movementSpeed = originalSpeed;
    }
}



