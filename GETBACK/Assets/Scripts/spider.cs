using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    public Transform player;
    public float lungeSpeed = 10f;
    public float lungeDuration = 0.5f;
    public float cooldownDuration = 2f;
    public float maxDistance = 10f;

    private bool isOnCooldown = false;
    void Start()
    {
        cooldownDuration = Random.Range(cooldownDuration - 1f, cooldownDuration + 1f);
    }
    private void Update()
    {
        if (!isOnCooldown)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= maxDistance)
            {
                // Start the lunge coroutine
                StartCoroutine(LungeCoroutine());
            }
        }
    }

    private IEnumerator LungeCoroutine()
    {
        isOnCooldown = true;

        // Calculate direction to player
        Vector2 direction = (player.position - transform.position).normalized;

        // Lunge towards the player for the specified duration
        float timer = 0f;
        while (timer < lungeDuration)
        {
            // Move the enemy towards the player with lunge speed
            transform.Translate(direction * lungeSpeed * Time.deltaTime);

            timer += Time.deltaTime;
            yield return null;
        }

        // Lunge duration reached, enter cooldown period
        yield return new WaitForSeconds(cooldownDuration);

        // Cooldown duration reached, reset cooldown
        isOnCooldown = false;
    }



    /*private GameObject player;
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
    }*/




}
