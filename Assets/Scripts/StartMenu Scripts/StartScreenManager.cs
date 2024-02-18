using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class StartScreenManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] newTexts;
    public float brzinaPromene = 3f;

    private int trenutnaPorukaID = 0;

    void Start()
    {
        InvokeRepeating("ChangeText", 0f, brzinaPromene);
    }

    void ChangeText()
    {
        textComponent.text = newTexts[trenutnaPorukaID];

        trenutnaPorukaID = (trenutnaPorukaID + 1) % newTexts.Length;
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
