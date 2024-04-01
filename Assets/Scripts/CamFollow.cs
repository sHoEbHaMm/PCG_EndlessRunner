using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = playerTransform.position + offset;
        targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
