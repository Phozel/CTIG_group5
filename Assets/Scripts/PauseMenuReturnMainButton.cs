using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PauseMenuReturnMainButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Button _button;

    PauseMenuController _pauseManager;
    LevelLoader _levelLoader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _pauseManager = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "PauseManager").GetComponent<PauseMenuController>();

        _levelLoader = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "LevelLoader").GetComponent<LevelLoader>();

        _button = GetComponent<Button>();
        if (_button == null)
        {
            Debug.LogError("No Button component found on " + gameObject.name);
            return;
        }
        _button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        _pauseManager.ResumeGame();
        _levelLoader.ReturnToMainMenu();
    }
}
