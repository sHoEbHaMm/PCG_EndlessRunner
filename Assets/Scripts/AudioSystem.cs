using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour, IObserver
{
    [SerializeField] AudioSource CoinSFX;
    [SerializeField] Subject _playerSubject;

    private void Start()
    {
        _playerSubject.AddObserver(this);
    }

    public void OnNotify()
    {
        if(CoinSFX)
        {
            CoinSFX.Play();
        }
    }
}
