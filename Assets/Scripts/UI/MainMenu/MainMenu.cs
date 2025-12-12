//Disclaimer: This code was mostly AI generated. We only modified it slightly to fit our needs.
//Therefore, we do not claim intellectual property over this code.

/*
 Co-created with ChatGPT
 */

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject levelSelectionPanel;
    public GameObject settingsPanel;

    [Header("Audio")]
    

    public GameObject muteButton;
    public Sprite muteSprite;
    public Sprite unmuteSprite;
    public UnityEngine.UI.Image buttonImage;
    private TextMeshProUGUI muteButtonText;
    private bool isMuted = false;

    [Header("Return Main Menu")]
    public GameObject returnMainMenuButton;


    void Start()
    {
        // Find TMP text inside the button automatically
        if (muteButton != null)
            muteButtonText = muteButton.GetComponentInChildren<TextMeshProUGUI>();

        // Optional: initialize text
        UpdateMuteButtonText();
    }

    // Main menu buttons
    public void OpenLevelSelection()
    {
        Debug.Log("Opening Level Selection");
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(true);
        settingsPanel.SetActive(false);
        returnMainMenuButton.SetActive(true);
    }

    public void OpenSettings()
    {
        Debug.Log("Opening Settings");
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(false);
        settingsPanel.SetActive(true);
        returnMainMenuButton.SetActive(true);
    }

    public void BackToMainMenu()
    {
        Debug.Log("Returning to Main Menu");
        mainMenuPanel.SetActive(true);
        levelSelectionPanel.SetActive(false);
        settingsPanel.SetActive(false);
        returnMainMenuButton.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;

        // Change button sprite if assigned
        if (buttonImage != null)
            buttonImage.sprite = isMuted ? muteSprite : unmuteSprite;

        // Change button text
        UpdateMuteButtonText();
    }

    private void UpdateMuteButtonText()
    {
        if (muteButtonText != null)
            muteButtonText.text = isMuted ? "M" : "S";
    }

}
