using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    
    private GameObject player;
    private enemy Enemy;

    void Start()
    {
        // Find the player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Player");
        Enemy = GetComponent<enemy>();


    }

    void Update()
    {
        // Check if the player GameObject is found
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = player.transform.position - transform.position;

            // Normalize the direction vector to get a unit vector
            direction.Normalize();

            // Move the enemy towards the player using the direction and movement speed
            transform.Translate(direction * Enemy.movementSpeed * Time.deltaTime);
        }
    }
}
