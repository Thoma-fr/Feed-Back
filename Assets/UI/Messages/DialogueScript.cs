using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    
    public Conversation[] Dialogues = new Conversation[]{
        new Conversation(){
            startDialogue = new []{"Coucou !", "Mes parents me tannent encore pour que je mange quelque chose. Ils peuvent pas se mêler de leurs affaires ?"},
            answerDialogue = new Tuple<string, string[]>[]{
                Tuple.Create("Les miens sont pareils…", new []{"Haha, bah bon courage à toi aussi alors."}),
                Tuple.Create("Peut-être qu’ils s'inquiètent pour toi ?", new []{"Tu penses ? Je sais pas trop…"}),
                Tuple.Create("En vrai, fait semblant, ils se calmeront.", new []{"Je vais essayer."})
            }
        }
    };
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(transform.name);
        Conversation convo = Dialogues[Random.Range(0, Dialogues.Length)];
        
        foreach (string str in convo.startDialogue)
        {
            GameObject obj = Instantiate(CompanionMessageItem, chatHolder);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = str;
        }

        foreach (Tuple<string, string[]> tuple in convo.answerDialogue)
        {
            GameObject obj = Instantiate(MessagePropositionItem, chatHolder);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = tuple.Item1;
            Debug.Log(obj.name);
            Button button = obj.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                foreach (Transform child in transform.transform)
                {
                    if (child.GetComponent<Button>() != null)
                    {
                        Destroy(child.gameObject);
                    }
                }

                GameObject obj2 = Instantiate(MessagePropositionItem, chatHolder);
                obj2.GetComponentInChildren<TextMeshProUGUI>().text = tuple.Item1;

                foreach (string str in tuple.Item2)
                {
                    GameObject obj3 = Instantiate(CompanionMessageItem, chatHolder);
                    obj3.GetComponentInChildren<TextMeshProUGUI>().text = str;
                }
            });
        }
        
        /*
        GameObject CompanionMessage = Instantiate(CompanionMessageItem, chatHolder);
        CompanionMessage.GetComponentInChildren<TextMeshProUGUI>().text = "First try bitch";
        
        GameObject MessageProposition = Instantiate(MessagePropositionItem, chatHolder);
        MessageProposition.GetComponentInChildren<TextMeshProUGUI>().text = "First responders";
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
