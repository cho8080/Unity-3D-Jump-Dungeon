using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 20f; // 튕겨 오르는 힘

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // 아래 방향 속도를 초기화한 후
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            // 점프
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
