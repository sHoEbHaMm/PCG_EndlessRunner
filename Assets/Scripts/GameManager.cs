using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour, IScoreObserver
{
    public TMP_Text scoreNumberText;
    public TMP_Text coinNumberText;
    int score, coins;
    public bool isPlayerDead = false;
    ScoreSystem scoreSystem;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreSystem = FindObjectOfType<ScoreSystem>();
        scoreSystem.AddObserver(this);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDead == false)
        {
            StartCoroutine(nameof(ScoreIncrementer));
            scoreNumberText.text = score.ToString();
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
        scoreSystem.IncreaseScore(1);
        audioSource.Play();
    }

    public void OnScoreChanged(int score)
    {
        coinNumberText.text = scoreSystem.coins.ToString();
    }
}
