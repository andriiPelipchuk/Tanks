using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamsType 
{
    BlueTeam,
    RedTeam
}

[RequireComponent(typeof(LevelConstructor))]
 
public class GameController : MonoBehaviour
{
    private LevelConstructor generationLevel;
    private InstallationTanks[] installationTanks;

    private void Start()
    {
        generationLevel = GetComponent<LevelConstructor>();
        installationTanks = FindObjectsOfType<InstallationTanks>();

        generationLevel.AddNewWall();

        for(int i = 0; i < installationTanks.Length ; i++)
        {
            installationTanks[i].InstallationTank();
        }
    }
}
