using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanNoc : MonoBehaviour
{
    public float rotationSpeed = 1f;

    void Update()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

        ClampRotation();
    }

    void ClampRotation()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, 0f, 360f);
        transform.eulerAngles = currentRotation;
    }
}
