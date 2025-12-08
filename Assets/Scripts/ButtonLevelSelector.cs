using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelNumber = -1;
    private Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
        if (_button == null)
        {
            Debug.LogError("No Button component found on " + gameObject.name);
            return;
        }

        //Derive level number from button name
        GetLevelNumberFromButtonName();

        // Find the LevelLoader in the scene
        LevelLoader loader = GameObject.Find("Managers/LevelLoader")?.GetComponent<LevelLoader>();
        if (loader != null)
        {
            _button.onClick.AddListener(() => loader.LoadLevel(levelNumber));
            Debug.Log("Assigned Level " + levelNumber + " to button " + gameObject.name);
        }
        else
        {
            Debug.LogError("LevelLoader not found in scene!");
        }
    }



    private void GetLevelNumberFromButtonName()
    {
        // Find the buttonNumber in the name if not set. Name is typically LevelXButton with X being the level number
        if (levelNumber == -1)
        {
            string name = gameObject.name; // e.g., "Level3Button"
            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    string numberStr = "";
                    while (i < name.Length && char.IsDigit(name[i]))
                    {
                        numberStr += name[i];
                        i++;
                    }
                    if (int.TryParse(numberStr, out int parsedNumber))
                    {
                        levelNumber = parsedNumber;
                        break;
                    }
                }
            }
        }
    }
}