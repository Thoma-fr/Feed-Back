using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public struct CharacterState
{
    [field: SerializeField] public String StateName {get;set;}
    [field: SerializeField] public Sprite StateSprite {get;set;}
    
}
public class Character : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Slider MealCountSlider;
    [field: SerializeField] public int MealCount { get; set; }
    [field: SerializeField] public int MealObjectif { get; set; }
    public int DayCount { get; set; }
    
    [field: SerializeField] public int BaseState { get; set; }
    public int CurrentStateIndex { get; set; }
    [field: SerializeField] public CharacterState CurrentState { get; set; }
    [field: SerializeField] public List<CharacterState> CharacterStates {get;set;}

  
    [field: SerializeField] public TextMeshProUGUI MoodCountText {get;set;}


    public static Character Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer.instance.OnTimerEnd.AddListener(Evaluate);
        CurrentState=CharacterStates[CurrentStateIndex];
        Instance=this;
        ApplyState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
[Button]
    public void Eat()
    {
        MealCount++;
        MealCountSlider.value = MealCount;
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
        MealCountSlider.value = 0;
    }

    void ChangeState(bool isGaining)
    {
        MealCount = 0;
        if (isGaining)
        {
            if(CurrentStateIndex==0)
                return;
            CurrentStateIndex--;
        }
        else
        {
            if(CurrentStateIndex<=CharacterStates.Count)
                return; 
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
