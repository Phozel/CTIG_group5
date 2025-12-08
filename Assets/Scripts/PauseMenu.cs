using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseMenuUI; // assign your PauseMenu panel here
    
    public GameObject LevelLoader; // assign your LevelLoader object here
    private LevelLoader Level_LoaderScript;
    private UI_Loader UI_LoaderScript;
    public GameObject UIController; // assign your UIController object here
    private bool isPaused = false;


    void Awake()
    {
        if (pauseMenuUI == null || LevelLoader == null || UIController == null)
            Debug.LogError("PauseMenuController: One or more UI references are not assigned in the inspector.");
        
        Level_LoaderScript = LevelLoader.GetComponent<LevelLoader>();
        UI_LoaderScript = UIController.GetComponent<UI_Loader>();
    }


    void Update()
    {
        // Toggle pause menu when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void ResumeGame()
    {
        UI_LoaderScript.TogglePauseMenu();
        Time.timeScale = 1f;
        isPaused = false;
    }

    /// <summary>
    /// Pause the game
    /// </summary>
    public void PauseGame()
    {
        UI_LoaderScript.TogglePauseMenu();
        Time.timeScale = 0f;
        isPaused = true;
    }

    /// <summary>
    /// Return to main menu
    /// </summary>
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // reset time scale before changing scene
        if (LevelLoader != null)
            LevelLoader.GetComponent<LevelLoader>().ReturnToMainMenu();
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
