using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelLoader : MonoBehaviour
{
    private int _currentLoadedLevel = -1;

    private GameObject _mainMenu;
    private GameObject _inLevelElements;

    public GameObject _UIController;
    private UI_Loader _uiLoader;

    private GameObject _pauseManager;
    private PauseMenuController _pauseMenuScript;

    void Awake()
    {
        // Find persistent in-level elements
        _inLevelElements = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "InLevel");
        if (_inLevelElements == null)
            Debug.LogError("LevelLoader: Found no InLevel persistent elements.");
        
        _mainMenu = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "UI_MainMenu");
        if(_mainMenu == null)
            Debug.LogError("LevelLoader: Didn't find MainMenu UI.");
        
        _pauseManager = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "PauseManager");

        if(_pauseManager == null)
            Debug.LogError("LevelLoader: Found no PauseManager object.");
        
        if(_UIController == null)
            Debug.LogError("LevelLoader: No UIController assigned!");

        _uiLoader = _UIController.GetComponent<UI_Loader>();
        _pauseMenuScript = _pauseManager.GetComponent<PauseMenuController>();

    }

    // Public API
    public void LoadLevel(int levelNumber)
    {
        StartCoroutine(LoadLevelRoutine(levelNumber));
        
    }

    private IEnumerator LoadLevelRoutine(int levelNumber)
    {
        // unload previous
        if (_currentLoadedLevel != -1)
        {
            var unloadOp = SceneManager.UnloadSceneAsync("Level_" + _currentLoadedLevel);
            while (!unloadOp.isDone) yield return null;
            _currentLoadedLevel = -1;
        }

        //inactivate MainMenu
        _mainMenu.SetActive(false);
        //activate inLevelElements
        _inLevelElements.SetActive(true);
        // load next additively
        var loadOp = SceneManager.LoadSceneAsync("Level_" + levelNumber, LoadSceneMode.Additive);
        while (!loadOp.isDone) yield return null;
        _currentLoadedLevel = levelNumber;
        _uiLoader.LoadHUDUI();
        _pauseManager.SetActive(true);

    }

    // optional: synchronous call if you must
    public void LoadLevelImmediate(int levelNumber)
    {   
        // unload previous
        if (_currentLoadedLevel != -1)
            SceneManager.UnloadSceneAsync("Level_" + _currentLoadedLevel);
        
        //inactivate MainMenu
        _mainMenu.SetActive(false);
        //activate inLevelElements
        _inLevelElements.SetActive(true);
        // load next additively
        SceneManager.LoadScene("Level_" + levelNumber, LoadSceneMode.Additive);
        
        _currentLoadedLevel = levelNumber;
        _uiLoader.LoadHUDUI();
        _pauseManager.SetActive(true);
    }

    public void ReturnToMainMenu()
    {

        
        //Should be dead code, just for safety
        if (_currentLoadedLevel != -1)
        {
            SceneManager.UnloadSceneAsync("Level_" + _currentLoadedLevel);
            _currentLoadedLevel = -1;
        }

        // reset uiLoader HUD elements
        _uiLoader.ResetHUDUI();

        // reset inLevel elements
        foreach (var obj in _inLevelElements.GetComponentsInChildren<ResettableObject>())
            obj.ResetTransform();

        // reactivate MainMenu
        _mainMenu.SetActive(true);
        _uiLoader.LoadMainMenuUI();
        _pauseManager.SetActive(false);
        _inLevelElements.SetActive(false);
    }

    public void ActivatePersistentInGameElements()
    {
        _inLevelElements.SetActive(true);
    }

    public void HidePersistentInGameElements()
    {
        _inLevelElements.SetActive(false);
    }   
}
