using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;

public class PlayerMovement : Subject
{
    public float speed = 5;
    private Rigidbody playerRBD;
    private Vector3 directionSideWays;
    private float sidewaysMovementMultiplier = 35f;
    private Camera mainCamera;
    bool alive = true;
    bool isInAir = false;
    GameManager gameManager;
    public float jumpForce; 
    public LayerMask groundMask;
    CameraShake cameraShake;

    private void Awake()
    {
        gameObject.SetActive(true);
        gameManager = FindObjectOfType<GameManager>();
        cameraShake = FindObjectOfType<CameraShake>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRBD = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //moveleft
                directionSideWays = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //moveright
                directionSideWays = Vector3.right;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !isInAir)
            {
                Jump();
            }
            else
            {
                //do nothing
                directionSideWays = Vector3.zero;
            }
        }

        if(transform.position.y < -3)
            Invoke(nameof(Restart), 1f);
    }

    private void FixedUpdate()
    {
        MoveForward();
        playerRBD.AddForce(directionSideWays * sidewaysMovementMultiplier);
        isInAir = !isGrounded();
    }

    void MoveForward()
    {
        Vector3 moveVector = transform.forward * speed * Time.deltaTime;
        playerRBD.MovePosition(playerRBD.position + moveVector);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            gameManager.isPlayerDead = true;
            Invoke(nameof(Restart), 1f);
        }
        else if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            //gameManager.AddACoin();
            NotifyObservers();
            speed += 0.1f;
            sidewaysMovementMultiplier += 0.1f;
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        playerRBD.AddForce(Vector3.up * jumpForce);
    }

    bool isGrounded()
    {
        RaycastHit raycastHit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out raycastHit, 2f, groundMask))
        {
            //Debug.Log("On Ground");
            return true;
        }

        //Debug.Log("------ Not On Ground");
        return false;
    }
}
