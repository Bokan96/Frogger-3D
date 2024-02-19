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
        PomeriSe();
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        if ( (startX<endX && transform.position.x > endX) || (startX>endX && transform.position.x < endX) )
            ResetujPozicijuX();
    }

    void PomeriSe()
    {
        Vector3 pomeraj = new Vector3(1f, 0f, 0f);  
        if(startX>endX)
            pomeraj = new Vector3(-1f, 0f, 0f);

        transform.Translate(pomeraj * moveSpeed * Time.deltaTime, Space.World);
    }

    void ResetujPozicijuX()
    {
        Vector3 novaPozicija = new Vector3(startX, transform.position.y, transform.position.z);
        transform.position = novaPozicija;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = null;
    }
}
