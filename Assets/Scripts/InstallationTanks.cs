using System;
using System.Collections.Generic;
using UnityEngine;

public class InstallationTanks : MonoBehaviour
{
    [SerializeField] private TeamsType _teamType;
    [SerializeField] private TeamsType _enemyTeamType;
    [SerializeField] private GameObject _enemyBase;
    [SerializeField] private Testing testing;
    
    [Header("Turcks")]
    [SerializeField] private GameObject trucks;

    [SerializeField] private GameObject[] _base; 

    [Header("Tower")]
    [SerializeField] private GameObject[] towers_;

    [Header("Cannon Fast")]
    [SerializeField] private GameObject[] cannonFast_;

    [Header("Cannon Power")]
    [SerializeField] private GameObject[] cannonPower_;

    [Header("Start Tank Position")]
    [SerializeField] private Vector3 installationPosition;

    private Quaternion dirrectionTank;
    private int randomModule;
    public void InstallationTank()
    {
        DirectionTank();
        InstallTank();
    }

    private void InstallTank()
    {
        GameObject truck = Instantiate(trucks, installationPosition, dirrectionTank);

        truck.tag = _teamType.ToString();
        var botBehaviour = truck.GetComponent<BotsBehavior>();
        botBehaviour?.SetEnemyTag(_enemyTeamType.ToString());
        botBehaviour?.SetEnemyBase(_enemyBase);

        RandomModule();
        GameObject bases = Instantiate(_base[randomModule], installationPosition, dirrectionTank);
        bases.transform.SetParent(truck.transform);

        RandomModule();
        GameObject tower = Instantiate(towers_[randomModule], installationPosition, dirrectionTank);
        tower.transform.SetParent(truck.transform);

        RandomModule();
        int selectGun = UnityEngine.Random.Range(0, 2);
        GameObject cannon;
        if (selectGun == 0)
            cannon = Instantiate(cannonFast_[randomModule], installationPosition, dirrectionTank);
        else
            cannon = Instantiate(cannonPower_[randomModule], installationPosition, dirrectionTank);
        cannon.transform.SetParent(truck.transform);

    }

    private void RandomModule()
    {
        randomModule = UnityEngine.Random.Range(0, 3);
    }

    private void DirectionTank()
    {
        if (installationPosition.x < 0)
        {
            dirrectionTank = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            dirrectionTank = Quaternion.Euler(0, 0, 180);
        }
    }
}
