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

    // 아이템 정보 넘겨주기
    public string GetInteractPromt()
    {
        string str = $"{data.itemName}\n{data.description}";
        return str;
    }
    // 플레이어가 상호작용키 누르면
    public void OnInteract()
    {
        // 아이템 정보를 넘겨주고
        CharacterManager.Instance.Player.itemData = data;
       
        // 구독
        //CharacterManager.Instance.Player.addItem -= inventory.AddItem;
        //CharacterManager.Instance.Player.addItem += inventory.AddItem;
        CharacterManager.Instance.Player.UnsubscribeAddItem(inventory.AddItem);
        CharacterManager.Instance.Player.SubscribeAddItem(inventory.AddItem);

        // addItem에 연결된 함수를 실행한다.
        // CharacterManager.Instance.Player.addItem?.Invoke();
        CharacterManager.Instance.Player.InvokeAddItem();

         CharacterManager.Instance.Player.itemData = null;

        // 아이템 삭제하기
        Destroy(gameObject);
      
    }
}
