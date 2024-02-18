using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class StartScreenManager : MonoBehaviour
{
    public TextMeshProUGUI uiImena;
    public string[] listaImena;
    public float brzinaPromene = 3f;

    private int trenutnaPorukaID = 0;

    void Start()
    {
        InvokeRepeating("PromeniTekst", 0f, brzinaPromene);
    }

    void PromeniTekst()
    {
        uiImena.text = listaImena[trenutnaPorukaID];

        trenutnaPorukaID = (trenutnaPorukaID + 1) % listaImena.Length;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
