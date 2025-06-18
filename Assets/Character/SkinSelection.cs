using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class SkinSelection : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(CheckSTreak());
    }

    private IEnumerator CheckSTreak()
    {
        for (int i = 0; i < buttons.Count-1; i++)
        {
            if (Character.Instance.goodStreak>i)
            {
                buttons[i].GetComponent<Button>().interactable = true;
                buttons[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
            else
            {
                buttons[i].GetComponent<Button>().interactable = false;
                buttons[i].transform.GetChild(0).GetComponentInChildren<Image>().enabled = true;
            }
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine(CheckSTreak());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
