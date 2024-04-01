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

    // Start is called before the first frame update
    void Start()
    {
        playerRBD = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //moveleft
            directionSideWays = Vector3.left;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //moveright
            directionSideWays = Vector3.right;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            directionSideWays = Vector3.up * 3;
        }
        else
        {
            //do nothing
            directionSideWays = Vector3.zero;
        }

        if(transform.position.y < -3)
            Invoke(nameof(Restart), 2f);

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
            Invoke(nameof(Restart), 2f);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
