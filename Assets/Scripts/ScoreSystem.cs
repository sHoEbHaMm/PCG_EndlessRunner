using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour, IObserver
{
    [SerializeField] Subject _playerSubject;
    [SerializeField] TMP_Text scoreText;

    int numberOfCoinsCollected = 0;

    public int GetNumberOfCoinCollected() { return numberOfCoinsCollected; }

    private void Start()
    {
        _playerSubject.AddObserver(this);
    }

   public void OnNotify()
   {
        numberOfCoinsCollected++;
        scoreText.text = numberOfCoinsCollected.ToString();
   }
}
