using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITarget
{
	[SerializeField] private float _enemyBaseHealth = 50f;

	public void Hit(float damage)
	{
		if (_enemyBaseHealth <= 0)
			EnemyDeathSequence();

		_enemyBaseHealth -= damage;
	}

	private void EnemyDeathSequence()
	{
		//TODO: Play enemy laugh animation for 5 seconds, then delete enemy
		Debug.Log("Enemy Death Test");
		Destroy(gameObject);
	}
}
