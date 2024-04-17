using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreObserver
{
    // Start is called before the first frame update
    void OnScoreChanged(int newScore);
}
