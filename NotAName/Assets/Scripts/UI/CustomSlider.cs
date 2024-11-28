using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_InputField inputField;

    public int value;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        value = (int)slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != value)
        {
            value = (int)slider.value;
            inputField.text = value.ToString();
        }
        else if (inputField.text != value.ToString())
        {
            if (int.TryParse(inputField.text, out int result))
            {
                if (result >= slider.minValue && result <= slider.maxValue)
                {
                    value = result;
                    slider.value = value;
                }
            }
        }
    }

    public void UpdateValue(float newValue)
    {
        value = (int)newValue;
        inputField.text = value.ToString();
        slider.value = value;
    }
}
