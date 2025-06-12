using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    public CanvasGroup foodMenuGroup;
    public CanvasGroup configGroup;
    public CanvasGroup pinCodeGroup;
    public CanvasGroup feedbackGroup;

    [Header("Config Access")]
    public string accessCode = "1234";

    public FoodMenuManager foodMenuManager;

    public bool isFoodMenuOpen = false;
    public bool isConfigOpen = false;
    public bool isFeedbackOpen = false;

    void Start()
    {
        foodMenuGroup.gameObject.SetActive(false);
        configGroup.gameObject.SetActive(false);
    }

    public void ToggleFoodMenu()
    {
        if (isConfigOpen) ClosePanel(configGroup, ref isConfigOpen);

        if (isFoodMenuOpen)
            ClosePanel(foodMenuGroup, ref isFoodMenuOpen);
        else
            OpenPanel(foodMenuGroup, ref isFoodMenuOpen);
    }

    public void ToggleConfigPanel()
    {
        if (isFoodMenuOpen) ClosePanel(foodMenuGroup, ref isFoodMenuOpen);

        if (pinCodeGroup.gameObject.activeSelf)
            ClosePanel(pinCodeGroup, ref isConfigOpen);
        else
            OpenPanel(pinCodeGroup, ref isConfigOpen);
    }
    public void OpenConfigAfterCode()
    {
        ClosePanel(pinCodeGroup, ref isConfigOpen);
        OpenPanel(configGroup, ref isConfigOpen);
    }

    public void ToggleFeedbackPanel()
    {
        // Ferme les autres panels si ouverts
        if (isFoodMenuOpen) ClosePanel(foodMenuGroup, ref isFoodMenuOpen);
        if (isConfigOpen) ClosePanel(configGroup, ref isConfigOpen);

        if (isFeedbackOpen)
            ClosePanel(feedbackGroup, ref isFeedbackOpen);
        else
            OpenPanel(feedbackGroup, ref isFeedbackOpen);
    }

    private void OpenPanel(CanvasGroup panel, ref bool stateFlag)
    {
        panel.gameObject.SetActive(true);
        panel.alpha = 0;
        panel.transform.localScale = Vector3.one * 0.8f;

        panel.DOFade(1f, 0.3f);
        panel.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);

        if (panel == foodMenuGroup && foodMenuManager != null)
        {
            foodMenuManager.ReplayAnimations();
        }

        stateFlag = true;
    }
    public void ForceClosePinPanel()
    {
        if (pinCodeGroup.gameObject.activeSelf)
            ClosePanel(pinCodeGroup, ref isConfigOpen);
    }

    private void ClosePanel(CanvasGroup panel, ref bool stateFlag)
    {
        panel.DOFade(0f, 0.2f);
        panel.transform.DOScale(0.8f, 0.2f).SetEase(Ease.InBack).OnComplete(() =>
        {
            panel.gameObject.SetActive(false);
        });

        stateFlag = false;
    }
}
