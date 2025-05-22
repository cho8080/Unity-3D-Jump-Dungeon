using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 정보 관리
public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;

    [SerializeField] private float curHp;
    [SerializeField] private float maxHp = 100f;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpPower = 5f;

    public float CurHp
    { get { return curHp; }
      set { curHp = value; }
    }

    public float MaxHp
    { get { return maxHp; } }

    public float MoveSpeed
    { get { return moveSpeed; } }

        public float JumpPower
    { get { return jumpPower; } }

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player = this;
        playerMovement = GetComponent<PlayerMovement>();

        curHp = maxHp;
    }
}
