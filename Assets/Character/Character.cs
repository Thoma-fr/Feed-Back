using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public struct CharacterState
{
    [field: SerializeField] public String StateName {get;set;}
    [field: SerializeField] public Sprite StateSprite {get;set;}
    
}
public class Character : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [field: SerializeField] public int MealCount { get; set; }
    [field: SerializeField] public int MealObjectif { get; set; }
    public int DayCount { get; set; }
    
    [field: SerializeField] public int BaseState { get; set; }
    public int CurrentStateIndex { get; set; }
    [field: SerializeField] public CharacterState CurrentState { get; set; }
    [field: SerializeField] public List<CharacterState> CharacterStates {get;set;}
    
    [field: SerializeField] public TextMeshProUGUI MealCountText {get;set;}
    [field: SerializeField] public TextMeshProUGUI MoodCountText {get;set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer.instance.OnTimerEnd.AddListener(Evaluate);
        CurrentState=CharacterStates[CurrentStateIndex];
        ApplyState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Evaluate()
    {
        if (MealObjectif > MealCount)
        {
            //lose state
            ChangeState(false);
        }
        else if (MealObjectif < MealCount)
        {
            //gainState
            ChangeState(true);
        }
    }

    void ChangeState(bool isGaining)
    {
        if (isGaining)
        {
            CurrentStateIndex--;
        }
        else
        {
            CurrentStateIndex++;
        }

        ApplyState();
    }

    void ApplyState()
    {
        CurrentState=CharacterStates[CurrentStateIndex];
        _spriteRenderer.sprite = CurrentState.StateSprite;
    }
}
