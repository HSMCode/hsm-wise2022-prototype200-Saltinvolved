using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float time = 0.0f;
    public float normalSpeed = 5f;
    public Rigidbody _playerRb;
    private bool isMoving = false;
    //private bool IsJumpPressed = false;
    private Vector3 moveDirection;

    // Variables for Item Collect
   
    public ParticleSystem Farts;
    public AudioSource fartSound;
    public GameObject astroBoi;

    // Boost Variablen 
    private float speed;
    public float speedBoost = 8.5f;
    public float speedBoostDuration = 2f;

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
       
        ProcessInputs();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("a"))
         {
            Vector3 newRot = new Vector3(16f, 230f, -2.6f);
            transform.rotation = Quaternion.Euler(newRot);

            }
        if (Input.GetKeyDown("d"))
         {
            Vector3 newRot = new Vector3(19f, 136f, 2.6f);
            transform.rotation = Quaternion.Euler(newRot);
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
        Destroy(other.gameObject);
        ActivateSpeedBoost();
    }
 }
       
    void EmitParticles()
    {
        Farts.Emit(50);
    }

}

