using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PauseMenuResumeButton : MonoBehaviour
{
    PauseMenuController _pauseManager;

    Button _button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _pauseManager = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "PauseManager").GetComponent<PauseMenuController>();

        _button = GetComponent<Button>();
        if (_button == null)
        {
            Debug.LogError("No Button component found on " + gameObject.name);
            return;
        }
        _button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void OnButtonClick()
    {
        _pauseManager.ResumeGame();
    }
}
