using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    #region Properties

    public Player currentPlayer;

    [SerializeField] private int highScore;
    
    [SerializeField] private int currentKillScore;
    [Space]
    [SerializeField] private int initialPlayerHp = 30;

    public bool levelStarted;

    #endregion

    #region Unity Events

    private void Start()
    {
        EventManager.OnGameStarted();
        LevelStarted();
        
        UIManager.instance.SetKillScore(currentKillScore);
    }

    private void OnEnable()
    {
        EventManager.GameStarted += SetHighestKillScore;
        EventManager.GameStarted += InitializePlayer;
        EventManager.GameStarted += ResetKillScore;

        EventManager.LevelFailed += LevelStopped;
    }

    private void OnDisable()
    {
        EventManager.GameStarted -= SetHighestKillScore;
        EventManager.GameStarted -= InitializePlayer;
        EventManager.GameStarted -= ResetKillScore;

        EventManager.LevelFailed -= LevelStopped;
    }

    #endregion

    #region Methods

    private void ResetKillScore()
    {
        currentKillScore = 0;
        UIManager.instance.SetKillScore(currentKillScore);
    }
    
    private void LevelStarted()
    {
        levelStarted = true;
    }

    private void LevelStopped()
    {
        levelStarted = false;
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
        currentPlayer.ResetPlayer();
    }
    
    public void EnableInput()
    {
        currentPlayer.EnableInput();
    }

    public void DisableInput()
    {
        currentPlayer.DisableInput();
    }

    #endregion
}
