using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class FeedbackManager : MonoBehaviour
{
    [Header("Input")]
    public TMP_InputField feedbackInput;
    public Button sendButton;

    [Header("Admin Log")]
    public Transform feedbackContentParent;
    public GameObject feedbackTextPrefab;

    private List<string> feedbacks = new List<string>();

    void Start()
    {
        sendButton.onClick.AddListener(SubmitFeedback);
    }

    public void SubmitFeedback()
    {
        string message = feedbackInput.text.Trim();
        if (string.IsNullOrEmpty(message)) return;

        feedbacks.Add(message);
        feedbackInput.text = "";
        AddToAdminLog(message);
    }

    private void AddToAdminLog(string message)
    {
        GameObject textObj = Instantiate(feedbackTextPrefab, feedbackContentParent);
        TMP_Text text = textObj.GetComponent<TMP_Text>();
        text.text = message;
    }
}
