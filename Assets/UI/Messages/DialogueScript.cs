using TMPro;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{

    public Transform chatHolder;
    public GameObject CompanionMessageItem;
    public GameObject MessagePropositionItem;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject CompanionMessage = Instantiate(CompanionMessageItem, chatHolder);
        CompanionMessage.GetComponent<TextMeshProUGUI>().text = "First try bitch";
        
        GameObject MessageProposition = Instantiate(MessagePropositionItem, chatHolder);
        MessageProposition.GetComponent<TextMeshProUGUI>().text = "First responders";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
