using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsBehavior : MonoBehaviour
{
    public Transform target;

    private string _enemyTag;
	private GameObject _enemyBase;
	private GameObject[] _enemies;
    private CharacterPathfindingMovementHandler _characterPathfinding;
	
	
	private float compareNumber;
	private float choseEnemy = 100f;


	private void Start()
	{
        _characterPathfinding = GetComponent<CharacterPathfindingMovementHandler>();
        _enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        RandomBehavior();
    }
    private void Update()
    {
        _characterPathfinding.SetTargetPosition(target.position);
    }
    public void SetEnemyTag(string enemyTag)
	{
		_enemyTag = enemyTag;
	}

	public void SetEnemyBase(GameObject enemyBase)
	{
		_enemyBase = enemyBase;
	}
	
	public void RandomBehavior()
	{
		int choseBehavior = UnityEngine.Random.Range(0, 2);
		if (choseBehavior == 0)
		{
			target = _enemyBase.transform;
		}

		else if (choseBehavior == 1)
		{
			Attacker();
		}
	}

	private void Attacker()
	{
		for (int i = 0; i <= _enemies.Length - 1; i++)
		{
			compareNumber = _enemies[i].transform.position.magnitude - transform.position.magnitude;
			if (compareNumber < choseEnemy)
			{
				choseEnemy = compareNumber;
				target = _enemies[i].transform;
			}
		}
	}
}