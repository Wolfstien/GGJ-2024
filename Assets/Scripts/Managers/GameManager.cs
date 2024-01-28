using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int Player1Score, Player2Score;
    public int RoundNo;

    void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    public void ResetTapLevelData()
    {
        Player1Score = 0;
        Player2Score = 0;
        RoundNo = 0;
    }
}
