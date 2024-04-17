using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour, IScoreObserver
{
    public TMP_Text scoreNumberText;
    public TMP_Text coinNumberText;
    public TMP_Text useGunText;
    int score, coins;
    public bool isPlayerDead = false;
    ScoreSystem scoreSystem;
    AudioSource audioSource;
    public GameObject gun;
    ShootingPowerUp powerUp;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreSystem = FindObjectOfType<ScoreSystem>();
        scoreSystem.AddObserver(this);
        audioSource = GetComponent<AudioSource>();
        powerUp = gun.GetComponent<ShootingPowerUp>();
        powerUp.enabled = false;
        useGunText.gameObject.SetActive(false);
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

        if(scoreSystem.coins == 10)
        {
            StartCoroutine(EnableGun());
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

    IEnumerator EnableGun()
    {
        useGunText.gameObject.SetActive(true);
        
        gun.gameObject.SetActive(true);
        powerUp.enabled = true;
        yield return new WaitForSeconds(10f);
        StartCoroutine(DisableGun());

    }

    IEnumerator DisableGun()
    {
        useGunText.gameObject.SetActive(false);
        powerUp.enabled = false;
        gun.gameObject.SetActive(false);
       
        yield return new WaitForSeconds(10f);
        StartCoroutine(EnableGun());
    }
}
