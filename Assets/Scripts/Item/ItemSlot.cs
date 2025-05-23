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

    // ������ Ŭ��������
    public void SlotClick()
    {           
        inventory.selectItem = item;

       // ��ü ���� �ƿ����� ��Ȱ��ȭ
        inventory.DisableAllOutLine();
        // �� ������ �ƿ����θ� Ȱ��ȭ
        outline.enabled = true;
    }
    // ������ ���
   public void ItemUse()
    {      
        if (item == null) { return; }

        quantity--;

        // ������ ���� �޾ƿ���
        float value = item.consumable.value;
        float duration = item.consumable.duration;

        // ü�� ȸ�� �������̶��
        if (item.consumable.type == ConsumableType.Health)
       {          
            // ü�� ����
            CharacterManager.Instance.Player.CurHp += value;
        }
        // ���ǵ� �� �������̶��
       else if(item.consumable.type == ConsumableType.SpeedBboost)
        {
            // ���ǵ� ����
            StartCoroutine(SpeedUp(value, duration));
        }
    
        outline.enabled = false;

        // �̹����� ���� ����
        Set();
    }

    // �̹����� ���� ����
    public void Set()
    {
        // ���� ����
        countText.text = quantity.ToString();

        // �������� �����Ѵٸ�
        if (quantity > 0)
        {
            // �̹��� ����
            icon.sprite = item.icon;
        }
        else
        {
            Clear();
        }
    }
    // ������ ����
    public void Clear()
    {    
        icon.sprite = null;
        quantity = 0;
        countText.text = quantity.ToString();
        item = null;
    }
    // ���ǵ� ��
    IEnumerator SpeedUp(float speed,float time )
    {
        CharacterManager.Instance.Player.MoveSpeed += speed;
        yield return new WaitForSeconds(time);
        CharacterManager.Instance.Player.MoveSpeed -= speed;
    }
}
