using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreNumberText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(nameof(ScoreIncrementer));
        scoreNumberText.text = score.ToString();
    }

    IEnumerator ScoreIncrementer()
    {
        score += 1;
        yield return new WaitForSeconds(10);
    }
}
