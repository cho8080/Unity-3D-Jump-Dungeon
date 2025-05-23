using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public interface IInteractable
{
    public string GetInteractPromt();
    public void OnInteract();
}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;
    public Inventory inventory;

    // ������ ���� �Ѱ��ֱ�
    public string GetInteractPromt()
    {
        string str = $"{data.itemName}\n{data.description}";
        return str;
    }
    // �÷��̾ ��ȣ�ۿ�Ű ������
    public void OnInteract()
    {
        // ������ ������ �Ѱ��ְ�
        CharacterManager.Instance.Player.itemData = data;
       
        // ����
        //CharacterManager.Instance.Player.addItem -= inventory.AddItem;
        //CharacterManager.Instance.Player.addItem += inventory.AddItem;
        CharacterManager.Instance.Player.UnsubscribeAddItem(inventory.AddItem);
        CharacterManager.Instance.Player.SubscribeAddItem(inventory.AddItem);

        // addItem�� ����� �Լ��� �����Ѵ�.
        // CharacterManager.Instance.Player.addItem?.Invoke();
        CharacterManager.Instance.Player.InvokeAddItem();

         CharacterManager.Instance.Player.itemData = null;

        // ������ �����ϱ�
        Destroy(gameObject);
      
    }
}
