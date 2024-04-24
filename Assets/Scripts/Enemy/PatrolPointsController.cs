using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PatrolPointsController : MonoBehaviour
{
    #region Properties

    [SerializeField] private List<PatrolController> allPatrolPoints = new List<PatrolController>();

    public List<int> patrolCountAccordingToLevel = new List<int>() {1, 2, 3, 4, 5, 6};

    #endregion

    #region Unity Events

    private void Start()
    {
        ActivatePatrolsAccordingToLevel();
    }

    private void OnEnable()
    {
        EventManager.PlayerLevelUp += ActivatePatrolsAccordingToLevel;
    }

    private void OnDisable()
    {
        EventManager.PlayerLevelUp -= ActivatePatrolsAccordingToLevel;
    }

    #endregion

    #region Methods

    private void ActivatePatrolsAccordingToLevel(int level)
    {
        ActivatePatrols(GetPatrolCount(level));
    }

    private void ActivatePatrolsAccordingToLevel()
    {
        ActivatePatrolsAccordingToLevel(LevelController.instance.currentPlayer.PlayerLevelController.CurrentLevel);
    }

    private int GetPatrolCount(int level)
    {
        int index = Mathf.Clamp(level - 1, 0, patrolCountAccordingToLevel.Count);

        return patrolCountAccordingToLevel[index];
    }

    private void ActivatePatrols(int count)
    {
        for (int i = 0; i < allPatrolPoints.Count; i++)
        {
            PatrolController patrolController=allPatrolPoints[i];
            bool activate = i < count;
            
            patrolController.gameObject.SetActive(activate);
        }
    }

    #endregion
}
