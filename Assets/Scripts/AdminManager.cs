using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AdminManager : MonoBehaviour
{
    [Header("Create Food UI")]
    public TMP_InputField nameInput;
    public TMP_InputField caloriesInput;
    public TMP_InputField fatInput;
    public TMP_InputField carbsInput;
    public TMP_InputField proteinInput;
    public Image selectedImagePreview;
    public Sprite defaultImage;

    [Header("Journal du jour")]
    public TextMeshProUGUI todayLogText;

    private Sprite selectedImage;
    private List<FoodItem> todaySelectedItems = new List<FoodItem>();

    void Start()
    {
        selectedImage = defaultImage;
        //selectedImagePreview.sprite = defaultImage;
    }

    public void SetSelectedImage(Sprite sprite)
    {
        selectedImage = sprite;
        //selectedImagePreview.sprite = sprite;
    }

    public void CreateFoodItem()
    {
        if (string.IsNullOrEmpty(nameInput.text)) return;

        FoodItem newItem = ScriptableObject.CreateInstance<FoodItem>();
        newItem.foodName = nameInput.text;
        newItem.calories = int.Parse(caloriesInput.text);
        newItem.fat = int.Parse(fatInput.text);
        newItem.carbs = int.Parse(carbsInput.text);
        newItem.protein = int.Parse(proteinInput.text);
        newItem.icon = selectedImage;

#if UNITY_EDITOR
        string path = $"Assets/FoodItems/{newItem.foodName}.asset";
        AssetDatabase.CreateAsset(newItem, path);
        AssetDatabase.SaveAssets();
#endif

        Debug.Log($"Nouveau food créé : {newItem.foodName}");
    }

    // 👉 Appelé après validation des aliments dans FoodMenuManager
    public void UpdateTodayLog(List<FoodItem> selectedItems)
    {
        todaySelectedItems = selectedItems;
        if (selectedItems == null || selectedItems.Count == 0)
        {
            todayLogText.text = "Aucun aliment sélectionné aujourd'hui.";
            return;
        }

        int totalKcal = 0, totalFat = 0, totalCarbs = 0, totalProtein = 0;
        string log = "<b>Journal alimentaire :</b>\n";

        foreach (var item in selectedItems)
        {
            log += $"- {item.foodName} : {item.calories} kcal (F:{item.fat}, C:{item.carbs}, P:{item.protein})\n";
            totalKcal += item.calories;
            totalFat += item.fat;
            totalCarbs += item.carbs;
            totalProtein += item.protein;
        }

        log += "\n<b>Total :</b>\n";
        log += $"{totalKcal} kcal | F:{totalFat} C:{totalCarbs} P:{totalProtein}";

        todayLogText.text = log;
    }
}
