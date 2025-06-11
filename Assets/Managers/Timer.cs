using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeBetweenNotificaion;
    [SerializeField] private float _timeForStateDuration;

    [SerializeField]  TextMeshProUGUI TimerText;
    public UnityEvent OnTimerEnd;
    private float _CurrentstateTime;
    void Awake()
    {
        _CurrentstateTime = _timeForStateDuration;
    }
    void Update()
    {
        _CurrentstateTime = Mathf.Max(0, _CurrentstateTime - Time.deltaTime);
        if (_CurrentstateTime <= 0)
        {
           OnTimerEnd.Invoke(); 
        }
        if(TimerText)
            TimerText.text = $"{(int)(_CurrentstateTime/3600):D2}:{(int)(_CurrentstateTime/60)%60:D2}";
    }
}
