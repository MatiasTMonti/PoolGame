using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PoolTable poolTable;
    public WhiteBall whiteBall;
    public CueStick poolCue;

    void Update()
    {
        for (int i = 0; i < poolTable.GetHoles().Count; i++)
        {
            whiteBall.CheckHoles(poolTable.GetHoles()[i], poolTable.GetHoleRadius());
        }
    }
}
