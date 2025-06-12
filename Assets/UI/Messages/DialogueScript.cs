using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using NaughtyAttributes;
public class DialogueScript : MonoBehaviour
{

    public Transform chatHolder;
    public GameObject CompanionMessageItem;
    public GameObject MessagePropositionItem;
<<<<<<< HEAD
    
    [Serializable]public struct Conversation
=======

    public int lastConv = -1;

    public struct Conversation
>>>>>>> origin/feature/messages
    {
        public string[] startDialogue;

        public Tuple<string, string[]>[] answerDialogue;
        //[TextArea] public string arg;
    }
    
    public Conversation[] Dialogues = new Conversation[]{
        new Conversation(){
            startDialogue = new []{"Coucou !", "Mes parents me tannent encore pour que je mange quelque chose. Ils peuvent pas se mêler de leurs affaires ?"},
            answerDialogue = new Tuple<string, string[]>[]{
                Tuple.Create("Les miens sont pareils…", new []{"Haha, bah bon courage à toi aussi alors."}),
                Tuple.Create("Peut-être qu’ils s'inquiètent pour toi ?", new []{"Tu penses ? Je sais pas trop…"}),
                Tuple.Create("En vrai, fait semblant, ils se calmeront.", new []{"Je vais essayer."})
            }
        },
        new Conversation(){
            startDialogue = new []
            {
                "Coucou !", "Ma mère m’a spam pour que je lui envoie mon repas de ce soir parce qu’ils sont au restaurant.",
                "Sérieux j’aurais jamais dû lui apprendre à utiliser un portable x)","Je me suis fait une salade dans un bol et ça fait 15min je suis devant j’ai l’air stupide je te jure"
            },
            answerDialogue = new Tuple<string, string[]>[]{
                Tuple.Create("Allez, le plus difficile c’est de se lancer !", new []{"Ouais, on le fait ensemble ?"}),
                Tuple.Create("Boah, c’est pas une salade qui te fera prendre 2 kilos. C’est l’heure du spectacle !", new []{"Quoi, tu veux que je mange ma salade artistiquement ? Euh… Ça s'essaye."}),
                Tuple.Create("Tu peux la jeter, c’est pas comme s’ils allaient ouvrir la poubelle pour vérifier…", new []{"Tu t’avances beaucoup, mais je peux juste jeter qq chose d’autre par dessus"})
            }
        },
        new Conversation(){
            startDialogue = new []{"Hey !", "Aujourd’hui on m’as fait une présentation sur l’anorexie.",
                "Ils ont passé la séance à dire que c’était une maladie -_-","C’est quoi leur problème ? Ça aide à rester maigre, c’est bien nan ?"},
            answerDialogue = new Tuple<string, string[]>[]{
                Tuple.Create("Ils peuvent pas nous comprendre, abandonne.", new []{"Je sais pas s’ils sont jaloux ou juste bêtes, mais ça vaut pas le coup apparemment."}),
                Tuple.Create("Je sais pas si être maigre en permanence c’est normal…", new []{"Y’as plus maigre pour le coup…"}),
                Tuple.Create("Techniquement, ça respecte la définition médicale d’une maladie chronique.", new []{"Vraiment ? Attends, je regarde."})
            }
        }
    };

    public void loadNewConversation()
    {
        foreach (Transform child in transform.transform)
        {
            Destroy(child.gameObject);
        }
        
        Debug.Log(transform.name);
        int newConv = Random.Range(0, Dialogues.Length);
        while (newConv == lastConv)
        {
            newConv = Random.Range(0, Dialogues.Length);
        }
        lastConv = newConv;
        Conversation convo = Dialogues[newConv];
        
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
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loadNewConversation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
