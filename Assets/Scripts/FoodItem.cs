using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "Nutrition/Food Item")]
public class FoodItem : ScriptableObject
{
    public string foodName;
    public Sprite icon;
    public int calories;
    public int fat;
    public int carbs;
    public int protein;
}
