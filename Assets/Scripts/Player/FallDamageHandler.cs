using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamageHandler : MonoBehaviour
{
    IDamagealbe damagealbe;
    Rigidbody rb;
    private float maxSafeFallSpeed = -10f; // ���� ���� �ӵ� 
    private float fallDamageMultiplier = 2f;
    private float maxFallSpeed; // �߶� �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        damagealbe = GetComponent<IDamagealbe>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // �������� �ӵ��� ���� ���� �ӵ����� �����ٸ�
        if (rb.velocity.y < maxSafeFallSpeed)
        {
            // �� �ӵ� ����
            maxFallSpeed = rb.velocity.y;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {       
            // �������� �ӵ��� ���� ���� �ӵ����� �����ٸ�
            if (maxFallSpeed < maxSafeFallSpeed)
            {
                // ���̿� ���� ������ ����ؼ�
                float damage = Mathf.Abs(rb.velocity.y + maxSafeFallSpeed) * fallDamageMultiplier;
                damage =  Mathf.RoundToInt(damage);
                // �ǰ�
                damagealbe?.TalkDamage(damage);
            }
            maxFallSpeed = 0; // �浹 �� �ʱ�ȭ
        }
    }
}
