using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Pathfinding
{
	[SerializeField]
	Vector3 target = new Vector3(0, 0, 0);

	void Update()
	{
		target = GetPlayer().transform.position;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			FindPath(transform.position, target);
		}

		Move();
	}

	PlayerController GetPlayer()
	{
		return FindObjectOfType<PlayerController>();
	}
}
