using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ItemSlot[] slots;
    [HideInInspector] public ItemData selectItem;

    // 아이템 증가
    public void AddItem()
    {  
        ItemData data = CharacterManager.Instance.Player.itemData;
        ItemSlot slot;

        // 인벤토리내에 데이터가 존재한다면
        if (GetItemSlot(data) != null)
        {
            // 해당 위치의 슬롯 가져오기
            slot = GetItemSlot(data);

            // 최대 개수를 초과했다면
            if (slot.quantity >= data.maxCount)
            {
                // 슬롯을 가져오지 않는다
                slot = null;
                return;
            }
        }
        else
        {
            // 빈 슬롯 가져오기
            slot = GetEmptySlot(data);
        }
        // 개수 증가
        slot.quantity++;
        slot.item = data;
        
        // UI 업데이트
        UpdateUI();
     
        return;

    }
    // 아이템 사용 클릭
    public void UseItemBtnClick()
    {
        if (selectItem == null) { return; }

        // 아이템이 담긴 해당 슬롯을 찾아옴
        ItemSlot slot = GetItemSlot(selectItem);

        // 전체 슬롯의 아웃라인 비활성화
        DisableAllOutLine();

        // 아이템 사용
        slot.ItemUse();
    }
    // 전체 슬롯의 아웃라인 비활성화
    public void DisableAllOutLine()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].outline.enabled = false;
        }
    }
    // 인벤토리 내에 해당 아이템이 있는지 검사
    //bool CheckItem(ItemData data)
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (slots[i].item == data)
    //        {
    //            return true;
    //        }
    //    }
    //}
    // 아이템이 있는 슬롯 가져오기
    ItemSlot GetItemSlot(ItemData data)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == data )
            {
                return slots[i];
            }
        }
        return null;
    }
    // 빈 슬롯 가져오기
    ItemSlot GetEmptySlot(ItemData data)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }
    // UI 업데이트
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
    
}
