using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� ���� ����
public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;

    [SerializeField] private float curHp;
    [SerializeField] private float maxHp = 100f;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpPower = 5f;

    // ���� ������ ȹ���� ������ ������
    public ItemData itemData;
    private Action addItem;

    public float CurHp
    { get { return curHp; }
      set { curHp = value; }
    }

    public float MaxHp
    { get { return maxHp; } }

    public float MoveSpeed
    { get { return moveSpeed; }
      set { moveSpeed = value; }
    }

        public float JumpPower
    { get { return jumpPower; } }

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player = this;
        playerMovement = GetComponent<PlayerMovement>();

        curHp = maxHp;
    }
    public void SubscribeAddItem(Action action) => addItem += action;
    public void UnsubscribeAddItem(Action action) => addItem -= action;
    public void InvokeAddItem() => addItem?.Invoke();

}
