using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

// �÷��̾� �̵� ����
public class PlayerMovement : MonoBehaviour
{
    int jumpCount;

    Vector2 move;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    // �̵�
    private void Move()
    {
        float moveSpeed = CharacterManager.Instance.Player.MoveSpeed;
        Vector3 direction = new Vector3(move.x, 0, move.y);
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
    // �̵� �Է� ó��
   public void OnMove(InputAction.CallbackContext context)
    {
         move = context.ReadValue<Vector2>();       
    }
    // ���� �Է� ó��
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed && jumpCount<2)
        {
            float jumpPower = CharacterManager.Instance.Player.JumpPower;
            rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpCount++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Map"))
        {
            jumpCount = 0;
        }
    }
}
