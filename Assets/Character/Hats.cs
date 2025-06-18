using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hats : MonoBehaviour
{
    public List<Sprite> hatsList = new List<Sprite>();
    public int hatIndex = 0;
    void Start()
    {
        
    }

    public void selecthat(int index)
    {
        GetComponent<SpriteRenderer>().sprite = hatsList[index];
    }

    public void RemoveHat()
    {
        hatIndex=0;
        GetComponent<SpriteRenderer>().sprite = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
