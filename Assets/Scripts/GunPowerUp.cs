using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GunPowerUp : MonoBehaviour
{
    [SerializeField] ScoreSystem scoreSystem;
    public TMP_Text useGunText;
    public Image LMB_IMG;
    RaycastHit raycast;
    bool bCanShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        useGunText.gameObject.SetActive(false);
        LMB_IMG.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreSystem.GetNumberOfCoinCollected() == 10) 
        {
            StartCoroutine(EnableGun());
        }

        if (gameObject.activeInHierarchy && bCanShoot)
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

    IEnumerator EnableGun()
    {
        useGunText.gameObject.SetActive(true);
        bCanShoot = true;
        LMB_IMG.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        StartCoroutine(DisableGun());

    }
    IEnumerator DisableGun()
    {
        useGunText.gameObject.SetActive(false);
        bCanShoot = false;
        LMB_IMG.gameObject.SetActive(false);
        yield return new WaitForSeconds(10f);
        StartCoroutine(EnableGun());
        Debug.Log("GUN IS BACK");
    }
}
