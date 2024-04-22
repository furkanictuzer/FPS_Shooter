using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] private Player playerPrefab;

    public Player CurrentPlayer; //{ get; private set; }

    [SerializeField] private int currentKillScore;
    private void Start()
    {
        EventManager.OnGameStarted();
    }

    private void OnEnable()
    {
        EventManager.GameStarted += SetHighestKillScore;
    }

    private void OnDisable()
    {
        EventManager.GameStarted -= SetHighestKillScore;
    }

    public void AddKillScore(int amount = 1)
    {
        currentKillScore += amount;
    }

    public void SaveHighestKill(int killScore)
    {
        UIManager.instance.SetHighestScore(killScore.ToString());
        PlayerPrefs.SetInt("KillScore", killScore);
    }

    private void SetHighestKillScore()
    {
        UIManager.instance.SetHighestScore(GetHighestKillScore().ToString());
    }
    
    public int GetHighestKillScore()
    {
        return PlayerPrefs.GetInt("KillScore");
    }

    private void SpawnPlayer()
    {
        if (CurrentPlayer != null)
        {
            Destroy(CurrentPlayer.gameObject);
            CurrentPlayer = null;
        }

        CurrentPlayer = Instantiate(playerPrefab.gameObject, transform.position, Quaternion.identity).GetComponent<Player>();
    }
}
