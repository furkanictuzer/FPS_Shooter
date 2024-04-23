using UnityEngine;

public class TalentController : Singleton<TalentController>
{
    [SerializeField] private int talentPoint;

    public int TalentPoint => talentPoint;

    private void Start()
    {
        ResetPoints();
    }

    private void ResetPoints()
    {
        EventManager.OnTalentPointChanged(TalentPoint);
    }
    
    public void AddTalentPoint(int amount = 1)
    {
        talentPoint += amount;
        EventManager.OnTalentPointChanged(TalentPoint);
    }
}
