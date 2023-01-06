using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float time = 0.0f;
    public float moveSpeed;
    public Rigidbody _playerRb;
    private bool isMoving = false;
    private bool IsJumpPressed = false;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //IsJumpPressed = Input.GetButtonDown(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsJumpPressed = true;
        }
        ProcessInputs();
    }

    void FixedUpdate()
    {
        if (IsJumpPressed)
        {
            _playerRb.velocity = new Vector3(0, 10, 0);
            isMoving = true;
            Debug.Log("jump");
        }

        if (isMoving)
        {
            time = time + Time.fixedDeltaTime;
            if (time > 10.0f)
            {
                Debug.Log(gameObject.transform.position.y + " : " + time);
            }
        }
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, moveY).normalized;
    }

    void Move()
    {
        _playerRb.velocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
