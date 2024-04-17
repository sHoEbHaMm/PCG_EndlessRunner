using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPowerUp : MonoBehaviour
{
    RaycastHit raycast;
    bool bShoot;
    // Start is called before the first frame update
    void Start()
    {
        bShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.forward, out raycast, 1000))
                {
                    if (raycast.collider.tag == "Obstacle")
                    {
                        Debug.Log("HITTTTTTTTTTTTTT");
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 25f, Color.yellow);
                        Destroy(raycast.collider.gameObject);
                    }
                }
            }
        }

    }

    private void FixedUpdate()
    {

    }
}
