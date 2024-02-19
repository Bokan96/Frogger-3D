using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanNoc : MonoBehaviour
{
    public float brzinaRotacije = 1f;
    void Update()
    {
        transform.Rotate(Vector3.right * brzinaRotacije * Time.deltaTime);

        ClampRotation();
    }

    void ClampRotation()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, 0f, 360f);
        transform.eulerAngles = currentRotation;
    }
}
