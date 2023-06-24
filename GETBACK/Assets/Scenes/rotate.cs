using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private Transform objectTransform;
    // Start is called before the first frame update
    void Start()
    {
        objectTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
         // Get the position of the mouse in the screen space
    Vector3 mousePosition = Input.mousePosition;

    // Convert the mouse position to world space
    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    // Calculate the direction from the object's position to the mouse position
    Vector3 direction = mouseWorldPosition - objectTransform.position;

    // Calculate the rotation angle based on the direction
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    // Rotate the object towards the mouse
    objectTransform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
