using UnityEngine;

public class LevelController : Singleton<LevelController>
{ 
    public Player currentPlayer;

    [SerializeField] private int highScore;
    
    [SerializeField] private int currentKillScore;
    [Space]
    [SerializeField] private int initialPlayerHp = 30;
    private void Start()
    {
        EventManager.OnGameStarted();
        
        UIManager.instance.SetKillScore(currentKillScore);
    }

    private void OnEnable()
    {
        EventManager.GameStarted += SetHighestKillScore;
        EventManager.GameStarted += InitializePlayer;
    }

    private void OnDisable()
    {
        EventManager.GameStarted -= SetHighestKillScore;
        EventManager.GameStarted += InitializePlayer;
    }

    public void AddKillScore(int amount = 1)
    {
        currentKillScore += amount;
        UIManager.instance.SetKillScore(currentKillScore);

        CheckHighScore(currentKillScore);
    }

    private void CheckHighScore(int killScore)
    {
        if (killScore > highScore)
        {
            SaveHighestKillScore(killScore);
        }
    }

    private void SaveHighestKillScore(int killScore)
    {
        highScore = killScore;
        UIManager.instance.SetHighestScore(highScore.ToString());
    }

    private void SetHighestKillScore()
    {
        UIManager.instance.SetHighestScore(highScore.ToString());
    }
    
    private void InitializePlayer()
    {
        currentPlayer.SetHp(initialPlayerHp);
    }
    
    public void EnableInput()
    {
        currentPlayer.EnableInput();
    }

    public void DisableInput()
    {
        currentPlayer.DisableInput();
    }
}
