using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float duzinaKoraka = 2.5f;
    public float visinaSkoka = 10f;
    
    public AudioSource zvukPokret;
    public AudioSource zvukSkok;

    private Animator animator;
    private bool spremanZaPokret = true; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.2f && PlayerColision.ziv){
            Jump();
        }

        else if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) && PlayerColision.ziv && spremanZaPokret)
        {
            MovePlayer();
        }
        else if (Input.GetKeyDown(KeyCode.E) && PlayerColision.ziv && spremanZaPokret)
        {
            animator.SetTrigger("Okret");
        }
    }

    // Move the player based on the last released arrow key
    void MovePlayer()
    {
        toggleSpremanZaPokret();
        Invoke("toggleSpremanZaPokret", 0.2f);
        Vector3 pomeraj = Vector3.zero;
        zvukPokret.Play();

        if (Input.GetKeyUp(KeyCode.LeftArrow) && transform.position.x > -28f)
        {
            pomeraj = Vector3.left;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && transform.position.x < 3f)
        {
            pomeraj = Vector3.right;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) && transform.position.z < 30f)
        {
            pomeraj = Vector3.forward;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && transform.position.z > -11f)
        {
            pomeraj = Vector3.back;
        }

        transform.position += pomeraj * duzinaKoraka;
        
        if(transform.position.y < 1.5f)                  // mali skok
            transform.position += Vector3.up * 1.2f;
        
        animator.SetTrigger("Pokret");
    }

    void Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, visinaSkoka, 0f);
        zvukSkok.Play();
        animator.SetTrigger("Skok");
    }

    void toggleSpremanZaPokret(){
        spremanZaPokret = !spremanZaPokret;
    }
}

