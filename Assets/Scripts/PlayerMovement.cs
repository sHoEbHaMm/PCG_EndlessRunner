using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody playerRBD;
    private Vector3 directionSideWays;
    private Camera mainCamera;
    bool alive;

    public float jumpForce; 
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        playerRBD = GetComponent<Rigidbody>();
        alive = true;
        playerRBD.constraints = RigidbodyConstraints.None;
        playerRBD.constraints = RigidbodyConstraints.FreezeRotation;
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
            else if (Input.GetKeyDown(KeyCode.Space))
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
        playerRBD.AddForce(directionSideWays * 35);
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
            alive = false;
            playerRBD.constraints = RigidbodyConstraints.FreezePosition;
            playerRBD.constraints = RigidbodyConstraints.FreezeRotation;
            Invoke(nameof(Restart), 1f);
        }
        else if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Jump()
    {
        // Check whether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        // If we are, jump
        playerRBD.AddForce(Vector3.up * jumpForce);
    }
}
