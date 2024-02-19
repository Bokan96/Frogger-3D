using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI zivotiText;
    public TextMeshProUGUI zabiceText;
    public int lives = 5;
    public int score = 0;
    public GameObject[] elementiKojiSeMenjaju;
    public AudioSource uiZvuk;

    private bool igraPauzirana = false;
    private AudioListener[] allListeners;

    void Start()
    {
        UpdateLivesUI();
        allListeners = FindObjectsOfType<AudioListener>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiZvuk.Play();
            TogglePause();
        }
    }

    public void TogglePause()
    {
        igraPauzirana = !igraPauzirana;

        ToggleElementsVisibility();

        if (igraPauzirana)
        {
            Time.timeScale = 0f;
            SetListenersVolume(0f);
        }
        else
        {
            Time.timeScale = 1f;
            SetListenersVolume(1f);
        }
    }

    void ToggleElementsVisibility()
    {
        foreach (GameObject element in elementiKojiSeMenjaju)
        {
            if (element != null)
            {
                element.SetActive(!element.activeSelf);
            }
        }
    }
    void SetListenersVolume(float volume)
    {
        foreach (AudioListener listener in allListeners)
        {
            if (listener != null)
            {
                AudioListener.volume = volume;
            }
        }
    }

    public void UpdateLivesUI()
    {
        zivotiText.text = "Ukupno Života\n";
        for(int i=0;i<lives;i++){
            zivotiText.text += "♥";
        }
        zabiceText.text = "Prevedenih Žabica: " + score;
    }

    public void DecreaseLives()
    {
        lives--;
        UpdateLivesUI();
    }
    public void IncreaseLives()
    {
        lives++;
        UpdateLivesUI();
    }

    public void exitGame()
    {
        SceneManager.LoadScene("StartMenu");
        TogglePause();
    }
}
