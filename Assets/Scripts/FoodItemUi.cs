using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FoodItemUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText;
    public GameObject highlight;

    [HideInInspector] public FoodItem foodItem;
    public bool isSelected = false;

    public void Setup(FoodItem item)
    {
        foodItem = item;
        icon.sprite = item.icon;
        nameText.text = item.foodName;
        //statsText.text = $"{item.calories} kcal | F:{item.fat} C:{item.carbs} P:{item.protein}";
        SetSelected(false);   
    }

    public void PlayAppearAnimation(float delay = 0f)
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        if (cg == null) cg = gameObject.AddComponent<CanvasGroup>();

        cg.alpha = 0;
        transform.localScale = Vector3.one * 0.8f;

        cg.DOFade(1f, 0.3f).SetDelay(delay);
        transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).SetDelay(delay);
    }


    public void ToggleSelection()
    {
        isSelected = !isSelected;
        SetSelected(isSelected);
    }

    private void SetSelected(bool selected)
    {
        highlight.SetActive(selected);
    }
}
