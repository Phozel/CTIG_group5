using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderBoundsAndValueDisplay : MonoBehaviour
{
    [Header("Slider and Texts")]
    public Slider slider;                  // The slider to read values from
    public TextMeshProUGUI minText;        // Left text for min value
    public TextMeshProUGUI maxText;        // Right text for max value
    public TextMeshProUGUI currentValueText; // Text to display current value

    [Header("Offset for Current Value Text")]
    public Vector3 valueTextOffset = new Vector3(0, 20, 0); // Offset above the handle

    private RectTransform handleRect;
    private Canvas parentCanvas;

    void Start()
    {
        if (slider != null)
        {
            handleRect = slider.handleRect;
            parentCanvas = slider.GetComponentInParent<Canvas>();

            if (minText != null)
                minText.text = slider.minValue.ToString();

            if (maxText != null)
                maxText.text = slider.maxValue.ToString();

            slider.onValueChanged.AddListener(OnSliderValueChanged);
            UpdateCurrentValueText();
        }
    }


    private void OnDestroy()
    {
        if (slider != null)
            slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        AudioManager.Instance.masterVolume = value;
        UpdateCurrentValueText();
    }

    void UpdateCurrentValueText()
    {
        if (currentValueText == null || handleRect == null) return;

        float temp_value = slider.value * 100;

        if (temp_value == 0)
            currentValueText.text = slider.value.ToString("0%");
        else
            currentValueText.text = slider.value.ToString("#%");

        Vector3 worldPos = handleRect.position + valueTextOffset;
        if (parentCanvas.renderMode != RenderMode.WorldSpace)
            currentValueText.rectTransform.position = RectTransformUtility.WorldToScreenPoint(parentCanvas.worldCamera, worldPos);
        else
            currentValueText.rectTransform.position = worldPos;
    }
}
