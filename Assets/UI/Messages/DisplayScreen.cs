using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class DisplayScreen : MonoBehaviour
{
    [SerializeField] private Transform _screenTransform;
    private Vector3 _BaseScreenTransform;
    void Start()
    {
        _BaseScreenTransform = _screenTransform.position;
    }

    [Button]
    public void DisplayTheScreen()
    {
        _screenTransform.DOMove(transform.position,0.5f).SetEase(Ease.OutBack);
    }
    [Button]
    public void RemoveScreen()
    {
        _screenTransform.DOMove(_BaseScreenTransform,0.5f).SetEase(Ease.OutBack);
    }
}
