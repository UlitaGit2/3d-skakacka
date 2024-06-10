using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 10;
    public float JumpForce = 5;
    public Rigidbody rb;
    private bool IsGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x: horizontal, y: 0f, z: vertical);
        transform.Translate(translation: movement * MoveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
                Jump();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGrounded = true;        
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
        IsGrounded = false;
    }
}
