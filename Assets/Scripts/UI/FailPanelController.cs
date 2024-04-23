using UnityEngine;

public class FailPanelController : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void OnEnable()
    {
        EventManager.GameStarted += Deactivate;
        EventManager.LevelFailed += Activate;
    }
    
    private void OnDisable()
    {
        EventManager.GameStarted -= Deactivate;
        EventManager.LevelFailed -= Activate;
    }

    private void Activate()
    {
        Cursor.lockState = CursorLockMode.None;
        panel.SetActive(true);
    }

    private void Deactivate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
    }
    public void RestartGame()
    {
        EventManager.OnGameStarted();
    }
}
