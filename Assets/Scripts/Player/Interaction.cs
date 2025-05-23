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
            ShowItemInfo(); // 1�ʿ� �ѹ��� ������ ���� Ž���ϱ�
        }
    }
    // ������ ���� Ž���ϱ�
    void ShowItemInfo()
    {
        // ���̸� �߻�
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
        {
            if(hit.collider.gameObject != curInteractGameObject)
            {
                curInteractGameObject = hit.collider.gameObject;
                // ������ ���� �����ֱ�
                SetItemText();
            }          
        }
        else
        {
            curInteractGameObject = null;
            itemText.gameObject.SetActive(false);
        }
    }
    // ������ ���� ���� �����ֱ�
    void SetItemText()
    {
        itemText.gameObject.SetActive(true);
        itemText.text = curInteractGameObject.GetComponent<ItemObject>().GetInteractPromt();
    }
    // ������ �Ա�
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractGameObject != null)
        {
            curInteractGameObject.GetComponent<ItemObject>().OnInteract();
            curInteractGameObject = null;

            itemText.gameObject.SetActive(false);  
        }
    }
    // �κ��丮 ����
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
