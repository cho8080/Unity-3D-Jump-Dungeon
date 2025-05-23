using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;

public class ItemSlot : MonoBehaviour
{
    public Inventory inventory;
    public ItemData item;
    public int quantity;
    public Image icon;
    public TMP_Text countText;
    public Outline outline;

    // 슬롯을 클릭했을때
    public void SlotClick()
    {           
        inventory.selectItem = item;

       // 전체 슬롯 아웃라인 비활성화
        inventory.DisableAllOutLine();
        // 내 슬롯의 아웃라인만 활성화
        outline.enabled = true;
    }
    // 아이템 사용
   public void ItemUse()
    {      
        if (item == null) { return; }

        quantity--;

        // 아이템 정보 받아오기
        float value = item.consumable.value;
        float duration = item.consumable.duration;

        // 체력 회복 아이템이라면
        if (item.consumable.type == ConsumableType.Health)
       {          
            // 체력 증가
            CharacterManager.Instance.Player.CurHp += value;
        }
        // 스피드 업 아이템이라면
       else if(item.consumable.type == ConsumableType.SpeedBboost)
        {
            // 스피드 증가
            StartCoroutine(SpeedUp(value, duration));
        }
    
        outline.enabled = false;

        // 이미지와 개수 설정
        Set();
    }

    // 이미지와 개수 설정
    public void Set()
    {
        // 개수 설정
        countText.text = quantity.ToString();

        // 아이템이 존재한다면
        if (quantity > 0)
        {
            // 이미지 설정
            icon.sprite = item.icon;
        }
        else
        {
            Clear();
        }
    }
    // 아이템 비우기
    public void Clear()
    {    
        icon.sprite = null;
        quantity = 0;
        countText.text = quantity.ToString();
        item = null;
    }
    // 스피드 업
    IEnumerator SpeedUp(float speed,float time )
    {
        CharacterManager.Instance.Player.MoveSpeed += speed;
        yield return new WaitForSeconds(time);
        CharacterManager.Instance.Player.MoveSpeed -= speed;
    }
}
