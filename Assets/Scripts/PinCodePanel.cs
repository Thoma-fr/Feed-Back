using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class PinCodePanel : MonoBehaviour
{
    public TextMeshProUGUI codeDisplay;
    public string correctCode = "1234";

    private string currentInput = "";
    public MenuManager menuManager;

    void Start()
    {
        UpdateDisplay();
        codeDisplay.text = "";
    }

    public void AddDigit(string digit)
    {
        if (currentInput.Length >= 6) return;
        currentInput += digit;
        UpdateDisplay();
    }

    public void ClearInput()
    {
        currentInput = "";
        UpdateDisplay();
    }

    public void ValidateCode()
    {
        if (currentInput == correctCode)
        {
            Debug.Log("Code correct");
            menuManager.OpenConfigAfterCode();
        }
        else
        {
            Debug.Log("Code incorrect");
            PlayErrorFeedback();
        }

        ClearInput();
    }

    private void PlayErrorFeedback()
    {
        // Shake sur le panel
        transform.DOShakePosition(0.4f, strength: new Vector3(10f, 0f, 0f), vibrato: 10, randomness: 90);

        // Flash rouge sur le fond du champ (si Text avec fond)
        Image bg = codeDisplay.GetComponentInParent<Image>();
        if (bg != null)
        {
            Color originalColor = bg.color;
            bg.color = Color.red;
            bg.DOColor(originalColor, 0.5f);
        }
    }


    private void UpdateDisplay()
    {
        codeDisplay.text = new string('*', currentInput.Length);
    }
}
