using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class FoodMenuManager : MonoBehaviour
{
    public Transform contentParent; // parent du ScrollView Content
    public GameObject foodItemUIPrefab;
    public List<FoodItem> foodItems;

    private List<FoodItemUI> itemUIInstances = new List<FoodItemUI>();
    public AdminManager adminManager;

    void Start()
    {
        PopulateFoodItems();
    }

    public void PopulateFoodItems()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        itemUIInstances.Clear();

        for (int i = 0; i < foodItems.Count; i++)
        {
            FoodItem item = foodItems[i];
            GameObject obj = Instantiate(foodItemUIPrefab, contentParent);
            FoodItemUI ui = obj.GetComponent<FoodItemUI>();
            ui.Setup(item);
            ui.PlayAppearAnimation(i * 0.1f);

            itemUIInstances.Add(ui);

            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(() => ui.ToggleSelection());
        }
    }

    public List<FoodItem> GetSelectedItems()
    {
        List<FoodItem> selected = new List<FoodItem>();
        foreach (var ui in itemUIInstances)
        {
            if (ui.isSelected)
                selected.Add(ui.foodItem);
        }
        return selected;
    }

    public void ReplayAnimations()
    {
        for (int i = 0; i < itemUIInstances.Count; i++)
        {
            itemUIInstances[i].PlayAppearAnimation(i * 0.05f);
        }
    }

    public void ValidateSelection()
    {
        List<FoodItem> selected = GetSelectedItems();
        adminManager.UpdateTodayLog(selected);
    }
}
