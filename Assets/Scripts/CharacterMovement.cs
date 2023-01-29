using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Variables for basic Movement
    private float time = 0.0f;
    [SerializeField] float normalSpeed = 6f;
    private Rigidbody _playerRb;
    private bool isMoving = false;
   
    private Vector3 moveDirection;

    // Variables for Item Collect
    public ParticleSystem fartsPs;
    private AudioSource fartSound;
    

    // Variables for Boost
    private float speed;
    [SerializeField] float speedBoost = 15f;
    [SerializeField] float speedBoostDuration = 2f;
    private bool boostActive = false;


    // Array for fart prefabs to randomly choose from
    public AudioSource[] FartsAr;
    

    

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

     void Update()
    {
        ProcessInputs();
        SpeedCheck();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            time = time + Time.fixedDeltaTime;
        }

        Move();
        RotatePlayer();
    }

   // Methods for Moving 
    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, moveY).normalized;
    }

    private void Move()
    {
        
        _playerRb.velocity = new Vector3(moveDirection.x * speed, moveDirection.y * speed);
    }

    private void RotatePlayer()
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
    }

    // Methods for Food Collect 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            EmitFartParticles(); 
            RandomFart();
            Destroy(other.gameObject);
            ActivateSpeedBoost();
        }
    }
    
    private void EmitFartParticles()
    {
        fartsPs.Emit(50);
    }

      public void RandomFart()
    {

            // Get a random slot from the Fart prefab array
            int number = Random.Range(0, FartsAr.Length);

            // Instantiate a clone from the prefab enemies at the previously generated position
            Instantiate(FartsAr[number]);

    }
    
    // methods for Boost 
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
    
    private void SpeedCheck()
    {
        if(boostActive)
        {
            speed = speedBoost;
        }
        else 
        {
            speed = normalSpeed;
        }
    }
}

