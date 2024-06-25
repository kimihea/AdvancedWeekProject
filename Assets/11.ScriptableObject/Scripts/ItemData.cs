using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Ammo,
    Food
}
public enum ConsumableType
{
    Health,
    Hunger,
    Ammo
}
public class ItemDateConsumable
{
    public ConsumableType type;
    public float value;
}
[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public ItemType type;
    public string displayName;
    public string displayInfo;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDateConsumable[] consumables;


}
