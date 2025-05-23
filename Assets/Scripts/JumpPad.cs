using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 20f; // ƨ�� ������ ��

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // �Ʒ� ���� �ӵ��� �ʱ�ȭ�� ��
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            // ����
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
