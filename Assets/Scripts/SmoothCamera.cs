using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform meta;
    public float ostrinaPokreta = 5f;

    void LateUpdate()
    {
        if (meta != null)
        {
            Vector3 zeljenaPozicija = meta.position;
            transform.position = Vector3.Lerp(transform.position, zeljenaPozicija, ostrinaPokreta * Time.deltaTime);
        }
    }
}
