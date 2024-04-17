using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private List<IScoreObserver> observers = new List<IScoreObserver>();
    public int coins = 0;

    public void AddObserver(IScoreObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IScoreObserver observer)
    {
        observers.Remove(observer);
    }

    public void IncreaseScore(int amount)
    {
        coins += amount;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach(var observer in observers)
        {
            observer.OnScoreChanged(coins);
        }
    }
}
