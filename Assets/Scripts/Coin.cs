using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IScoreObserver
{
    private ScoreSystem scoreSystem;

    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        scoreSystem.AddObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Coin")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            scoreSystem.IncreaseScore(1);
        }
    }

    public void OnScoreChanged(int score)
    {

    }
}
