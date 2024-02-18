using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI  livesText;
    public TextMeshProUGUI  scoreText;
    public int lives = 5;  // Set the initial number of lives here
    public int score = 0;
    public GameObject[] elementsToShowHide;

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
        // Toggle the visibility of UI elements
        foreach (GameObject element in elementsToShowHide)
        {
            if (element != null)
            {
                element.SetActive(!element.activeSelf);
            }
        }
    }
    void SetListenersVolume(float volume)
    {
        // Set the volume of all AudioListeners
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
        livesText.text = "Ukupno Života\n";
        for(int i=0;i<lives;i++){
            livesText.text += "♥";
        }
        scoreText.text = "Prevedenih Žabica: " + score;
    }

    // Call this method when you want to decrease lives
    public void DecreaseLives()
    {
        lives--;
        UpdateLivesUI();

        // You can add additional logic here, like checking for game over conditions
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
