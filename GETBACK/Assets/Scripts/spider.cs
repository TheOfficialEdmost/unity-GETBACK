using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        Vector3 velocity = direction.normalized * moveSpeed;
        transform.Translate(velocity * Time.deltaTime);
    }
}
