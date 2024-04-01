using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        else
        {
            //do nothing
            directionSideWays = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        MoveForward();
        playerRBD.AddForce(directionSideWays * 25);
    }

    void MoveForward()
    {
        Vector3 moveVector = transform.forward * speed * Time.deltaTime;
        playerRBD.MovePosition(playerRBD.position + moveVector);
    }
}
