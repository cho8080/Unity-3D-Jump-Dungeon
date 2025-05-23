using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ConsumableType
{
    Health,
    SpeedB​boost
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type; // 아이템 타입
    public float value; // 아이템 값
    public float duration; // 아이템 지속 시간
}
[CreateAssetMenu(fileName ="Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public Sprite icon;

    [Header("Consumable")]
    public ItemDataConsumable consumable; // 여기서 value 접근

    [Header("Stacking")]
    public int count; //현재 개수
    public int maxCount; //최대 개수

    public float GetValue()
    {
        return consumable != null ? consumable.value : 0f;
    }
}

