using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
            if (isPlayerDead == false)
            {
                StartCoroutine(nameof(ScoreIncrementer));
                scoreNumberText.text = score.ToString();
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
       
    }

    IEnumerator ScoreIncrementer()
    {
        score += 1;
        yield return new WaitForSeconds(10);
    }
}
