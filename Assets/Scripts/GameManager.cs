using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreNumberText;
    public TMP_Text coinNumberText;
    int score, coins;
    public bool isPlayerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDead == false)
        {
            StartCoroutine(nameof(ScoreIncrementer));
            scoreNumberText.text = score.ToString();
            coinNumberText.text = coins.ToString();
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    IEnumerator ScoreIncrementer()
    {
        score += 1;
        yield return new WaitForSeconds(10);
    }

    public void AddACoin()
    {
        coins += 1;
    }
}
