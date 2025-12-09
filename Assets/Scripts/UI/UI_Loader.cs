using System;
using UnityEngine;
using System.Linq;

public class UI_Loader : MonoBehaviour
{
    private GameObject _UI_mainMenu;
    private GameObject _UI_pauseMenu;
    private GameObject _UI_HUD;

    private GameObject _HUDController;
    private InLevelUI _HUDControllerScript;

    void Awake()
    {
        Transform uiRoot = GameObject.Find("UI").transform;
        _UI_mainMenu  = FindInChildrenRecursive(uiRoot, "UI_MainMenu")?.gameObject;
        _UI_HUD       = FindInChildrenRecursive(uiRoot, "UI_HUD")?.gameObject;
        _UI_pauseMenu = FindInChildrenRecursive(uiRoot, "UI_PauseMenu")?.gameObject;
        _HUDController = FindInChildrenRecursive(uiRoot, "HUDController")?.gameObject;
        _HUDControllerScript = _HUDController.GetComponent<InLevelUI>();
        
        if(_UI_mainMenu == null || _UI_HUD == null || _UI_pauseMenu == null)
            Debug.LogError("UI_Loader: Could not find all required UI elements!");


        _UI_mainMenu.SetActive(true);
        _UI_HUD.SetActive(false);
        _UI_pauseMenu.SetActive(false);
    }

    public void LoadMainMenuUI()
    {
        _UI_mainMenu.SetActive(true);
        _UI_HUD.SetActive(false);
        _UI_pauseMenu.SetActive(false);
    }
    public void LoadHUDUI()
    {
        _UI_mainMenu.SetActive(false);
        _UI_HUD.SetActive(true);
        _UI_pauseMenu.SetActive(false);
    }
    public void LoadPauseMenuUI()
    {
        _UI_mainMenu.SetActive(false);
        _UI_HUD.SetActive(false);
        _UI_pauseMenu.SetActive(true);
    }

    public void TogglePauseMenu()
    {
        if(!_UI_pauseMenu.activeSelf)
        {
            LoadPauseMenuUI();
        }
        else
        {
            LoadHUDUI();
        }
    }

    public void ResetHUDUI()
    {
        _HUDControllerScript.ResetUIElements();
    }

    Transform FindInChildrenRecursive(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name) return child;
            Transform found = FindInChildrenRecursive(child, name);
            if (found != null) return found;
        }
        return null;
    }
}

