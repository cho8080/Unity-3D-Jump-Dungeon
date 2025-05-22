using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamageHandler : MonoBehaviour
{
    IDamagealbe damagealbe;
    Rigidbody rb;
    private float maxSafeFallSpeed = -10f; // 안전 낙하 속도 
    private float fallDamageMultiplier = 2f;
    private float maxFallSpeed; // 추락 속도

    // Start is called before the first frame update
    void Start()
    {
        damagealbe = GetComponent<IDamagealbe>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // 떨어지는 속도가 안전 낙하 속도보다 빠르다면
        if (rb.velocity.y < maxSafeFallSpeed)
        {
            // 그 속도 저장
            maxFallSpeed = rb.velocity.y;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {       
            // 떨어지는 속도가 안전 낙하 속도보다 빠르다면
            if (maxFallSpeed < maxSafeFallSpeed)
            {
                float damage = Mathf.Abs(rb.velocity.y + maxSafeFallSpeed) * fallDamageMultiplier;
                damagealbe?.TalkDamage(damage);
            }
            maxFallSpeed = 0; // 충돌 후 초기화
        }
    }
}
