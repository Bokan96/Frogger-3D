using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColision : MonoBehaviour
{
    private Vector3 pocetnaPozicija = new Vector3(-2.5f, 0, -12.5f);
    public int maxLives = 5;
    public static Boolean ziv = true;
    
    public UIManager uiManager;
    public AudioSource zvukCilj;
    public AudioSource zvukUdarac;
    public AudioSource zvukGameOver;
    private Animator animator;


    void Start()
    {
        uiManager.lives = maxLives;
        animator = GetComponent<Animator>();
        ziv = true;
        transform.position = pocetnaPozicija;
    }

    void Update(){

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && ziv)
        {
            HandleObstacleCollision();
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            DotakaoCilj();
        }
    }
    
    void DotakaoCilj(){
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 20f, 0f);
        animator.SetTrigger("Okret");
        zvukCilj.Play();
        Invoke("ResetPlayerPosition", 1.5f);
        uiManager.score++;
        uiManager.UpdateLivesUI();
    }

    void HandleObstacleCollision()
    {
        ziv = false;
        uiManager.DecreaseLives();
        zvukUdarac.Play();
        animator.SetTrigger("RIP");

        if (uiManager.lives <= 0)
        {
            zvukGameOver.Play();
            Invoke("GameOver", 4f);
        }
        else
        {
            Invoke("ResetPlayerPosition", 1f);
        }
    }


    void ResetPlayerPosition()
    {
        ziv = true;
        transform.position = pocetnaPozicija;
    }

    void GameOver()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
