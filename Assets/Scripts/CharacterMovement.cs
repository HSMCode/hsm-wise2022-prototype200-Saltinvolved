using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float time = 0.0f;
    public float normalSpeed = 5f;
    public Rigidbody _playerRb;
    private bool isMoving = false;
    private bool IsJumpPressed = false;
    private Vector3 moveDirection;

    // Variables for Item Collect
   
    public ParticleSystem Farts;
    public AudioSource fartSound;
    public GameObject astroBoi;

    // Boost Variablen 
    private float speed;
    private float speedBoost = 8.5f;
    private float speedBoostDuration = 2f;

    private bool boostActive;



    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        boostActive = false; 
        if (boostActive)
        {
            speed = speedBoost;
        }
        else 
        {
            speed = normalSpeed;
        }
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
        
        _playerRb.velocity = new Vector3(moveDirection.x * speed, moveDirection.y * speed);
    }


// versuch Boost 
// Corutine 

public void ActivateSpeedBoost()
{
    StartCoroutine(SpeedBoostCooldown());
}

IEnumerator SpeedBoostCooldown()
{
    speed = speedBoost;
    yield return new WaitForSeconds(speedBoostDuration);
    speed = normalSpeed;

}

// Food Collect auf diesem script ? 

private void OnTriggerEnter(Collider other)
 {
    Debug.Log (other.name + " just hit "+ gameObject.name);
    if (other.CompareTag("Food"))
    {
        EmitParticles(); 
        fartSound.Play();
        //Destroy(other.GameObject);
        ActivateSpeedBoost();
    }
 }
       
    void EmitParticles()
    {
        Farts.Emit(50);
    }

}

