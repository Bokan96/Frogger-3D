using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KretanjeVozila : MonoBehaviour
{
    float moveSpeed = 10f;
    public float minSpeed = 10f;
    public float maxSpeed = 20f;
    public float startX = 0f;
    public float endX = 90f;

    void Update()
    {
        // Move the obstacle along the X-axis
        MoveObstacle();
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        // Check if the obstacle is beyond the reset point
        if ((startX<endX && transform.position.x > endX) || (startX>endX && transform.position.x < endX))
        {
            // Reset the X position
            
            ResetXPosition();
            
        }
    }

    void MoveObstacle()
    {
        
        Vector3 movement = new Vector3(1f, 0f, 0f);  
        if(startX>endX)
            movement = new Vector3(-1f, 0f, 0f);

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    void ResetXPosition()
    {
        // Reset the X position to the specified value
        Vector3 newPosition = new Vector3(startX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
