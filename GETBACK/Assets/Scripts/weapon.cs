using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform target;
    private bool isFlipped = false;

    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public int bulletSpeed;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Rotate gun
        if (Mathf.Abs(angle) > 90f)
        {
            if (!isFlipped)
            {
                isFlipped = true;
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            if (isFlipped)
            {
                isFlipped = false;
                transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
            }
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Shoot bullet
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the appropriate input for your game
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the bullet prefab at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        // Apply an initial velocity to the bullet in the forward direction
        bulletRigidbody.velocity = spawnPoint.right * bulletSpeed; // Adjust bulletSpeed as needed
    }

}
