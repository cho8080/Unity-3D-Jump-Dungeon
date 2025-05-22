using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 플레이어 상태 관리
public class PlayerStatus : MonoBehaviour, IDamagealbe
{
    public Image hpBar;

    public void TalkDamage(float damage)
    {
        CharacterManager.Instance.Player.CurHp -= damage;
        hpBar.fillAmount = CharacterManager.Instance.Player.CurHp/ CharacterManager.Instance.Player.MaxHp;
        if (CharacterManager.Instance.Player.CurHp <= 0)
        {
            CharacterManager.Instance.Player.CurHp = 0;
            Die();
        }
    }
    void Die()
    {

    }
}
