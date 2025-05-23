using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class Inventory : MonoBehaviour
{
    public ItemSlot[] slots;
    [HideInInspector] public ItemData selectItem;
    public TextMeshProUGUI healthText; 
    public TextMeshProUGUI speedText;

    private void OnEnable()
    {
        ShowPlayerAbility();
    }
    // �÷��̾� �ɷ�ġ ǥ��
    public void ShowPlayerAbility()
    {
        healthText.text = CharacterManager.Instance.Player.CurHp.ToString();
        speedText.text = CharacterManager.Instance.Player.MoveSpeed.ToString();
    }
    // ������ ����
    public void AddItem()
    {  
        ItemData data = CharacterManager.Instance.Player.itemData;
        ItemSlot slot;

        // �κ��丮���� �����Ͱ� �����Ѵٸ�
        if (GetItemSlot(data) != null)
        {
            // �ش� ��ġ�� ���� ��������
            slot = GetItemSlot(data);

            // �ִ� ������ �ʰ��ߴٸ�
            if (slot.quantity >= data.maxCount)
            {
                // ������ �������� �ʴ´�
                slot = null;
                return;
            }
        }
        else
        {
            // �� ���� ��������
            slot = GetEmptySlot(data);
        }
        // ���� ����
        slot.quantity++;
        slot.item = data;
        
        // UI ������Ʈ
        UpdateUI();
     
        return;

    }
    // ������ ��� Ŭ��
    public void UseItemBtnClick()
    {
        // ��ư ���õ� ���¿��� �����̽� �� ������ Ŭ�� �̺�Ʈ ���� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��ư ������ �ʵ��� ���õ� UI ����
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                EventSystem.current.SetSelectedGameObject(null);
            }     
        }
        if (selectItem == null) { return; }

        // �������� ��� �ش� ������ ã�ƿ�
        ItemSlot slot = GetItemSlot(selectItem);

        // ��ü ������ �ƿ����� ��Ȱ��ȭ
        DisableAllOutLine();

        // ������ ���
        slot?.ItemUse();
    }
    // ��ü ������ �ƿ����� ��Ȱ��ȭ
    public void DisableAllOutLine()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].outline.enabled = false;
        }
    }
    // �������� �ִ� ���� ��������
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
    // �� ���� ��������
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
    // UI ������Ʈ
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
