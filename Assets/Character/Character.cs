using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public struct CharacterState
{
    [field: SerializeField] String StateName {get;set;}
    [field: SerializeField] Sprite StateSprite {get;set;}
    
}
public class Character : MonoBehaviour
{
    [field: SerializeField] int MealCount { get; set; }
    [field: SerializeField] int DayCount { get; set; }
    [field: SerializeField] List<CharacterState> CharacterStates {get;set;}
    
    [field: SerializeField] TextMeshProUGUI MealCountText {get;set;}
    [field: SerializeField] TextMeshProUGUI MoodCountText {get;set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
