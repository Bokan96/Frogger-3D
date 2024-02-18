using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspektiva : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            if (transform.position.y < 6)
            {
                transform.position += Vector3.up;
            }
            else
                transform.position += Vector3.down * 4;

        }
    }
}
