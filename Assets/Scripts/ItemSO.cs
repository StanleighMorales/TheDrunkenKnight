using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [Header("Properties")]
    public float cooldown;
    public itemType item_type;
    public Sprite item_Sprite;
};

public enum itemType
{
    KeyItem,
    Potion_Green,
    Sword,
};
    