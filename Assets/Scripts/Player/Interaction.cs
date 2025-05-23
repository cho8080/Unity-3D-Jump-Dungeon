using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class Interaction : MonoBehaviour
{
    Camera camera;
    public float maxCheckDistance;
    public LayerMask layerMask;
    public GameObject curInteractGameObject;
    public TextMeshProUGUI itemText;
    public GameObject inventroy;

    // Update is called once per frame
    void Start()
    {
        camera = Camera.main;
        StartCoroutine(DelayedCheckLoop());
    }
    IEnumerator DelayedCheckLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            ShowItemInfo(); // 1초에 한번씩 아이템 정보 탐색하기
        }
    }
    // 아이템 정보 탐색하기
    void ShowItemInfo()
    {
        // 레이를 발사
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
        {
            if(hit.collider.gameObject != curInteractGameObject)
            {
                curInteractGameObject = hit.collider.gameObject;
                // 아이템 정보 보여주기
                SetItemText();
            }          
        }
        else
        {
            curInteractGameObject = null;
            itemText.gameObject.SetActive(false);
        }
    }
    // 아이템 정보 내용 보여주기
    void SetItemText()
    {
        itemText.gameObject.SetActive(true);
        itemText.text = curInteractGameObject.GetComponent<ItemObject>().GetInteractPromt();
    }
    // 아이템 먹기
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractGameObject != null)
        {
            curInteractGameObject.GetComponent<ItemObject>().OnInteract();
            curInteractGameObject = null;

            itemText.gameObject.SetActive(false);  
        }
    }
    // 인벤토리 열기
    public void OnInvenetroy(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if(!inventroy.activeInHierarchy)
            {
                inventroy.SetActive(true);
                return;
            }
            inventroy.SetActive(false);
        }
    }
 }
