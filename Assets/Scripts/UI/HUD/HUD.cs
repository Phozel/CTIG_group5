using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

/*
 Co-created with ChatGPT
 */
public class InLevelUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI textHeight;   // Top-left
    [SerializeField] private TextMeshProUGUI textTime;     // Top-right
    [SerializeField] private GameObject imageItemOverlay;  // Overlay icon

    private float timer = 0f;

    void Update()
    {
        UpdateHeight();
        UpdateTimer();
    }

    public void ResetUIElements()
    {
        timer = 0f;
        enabled = true; // Unfreeze timer on reset

        if (textHeight != null)
            textHeight.text = "Height: 0.0";

        if (textTime != null)
            textTime.text = "00:00.000";

        if (imageItemOverlay != null)
            imageItemOverlay.SetActive(false);
    }

    // ------------------------------
    // HEIGHT DISPLAY
    // ------------------------------
    private void UpdateHeight()
    {
        // Replace with your actual player Y reference if needed
        float playerHeight = GameObject.FindWithTag("Player").transform.position.y;

        textHeight.text = $"Height: {playerHeight:F1}";
    }

    // ------------------------------
    // STOPWATCH TIMER DISPLAY
    // ------------------------------
    private void UpdateTimer()
    {
        timer += Time.deltaTime;

        int minutes = (int)(timer / 60f);
        int seconds = (int)(timer % 60f);
        int ms = (int)((timer * 1000) % 1000);

        textTime.text = $"{minutes:00}:{seconds:00}.{ms:000}";
    }

    // ------------------------------
    // ITEM INVENTORY CONTROL
    // ------------------------------
    public void SetItemInInventory()
    {
        if (imageItemOverlay != null)
            imageItemOverlay.SetActive(true);
    }

    public void ClearItemFromInventory()
    {
        if (imageItemOverlay != null)
            imageItemOverlay.SetActive(false);
    }

    // Optional helper to test in inspector
    [ContextMenu("Test: Set Item")]
    private void TestSetItem() => SetItemInInventory();

    [ContextMenu("Test: Clear Item")]
    private void TestClearItem() => ClearItemFromInventory();
}
