using System;
using TMPro;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{

    public Transform chatHolder;
    public GameObject CompanionMessageItem;
    public GameObject MessagePropositionItem;

    public struct Conversation
    {
        public string[] startDialogue;
        public Tuple<string, string[]>[] answerDialogue;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject CompanionMessage = Instantiate(CompanionMessageItem, chatHolder);
        CompanionMessage.GetComponentInChildren<TextMeshProUGUI>().text = "First try bitch";
        
        GameObject MessageProposition = Instantiate(MessagePropositionItem, chatHolder);
        MessageProposition.GetComponentInChildren<TextMeshProUGUI>().text = "First responders";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
