using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Pathfinding
{
	[SerializeField]
	Vector3 target = new Vector3(0, 0, 0);

	[SerializeField]
	float minRecalcDist = 1f;

	[SerializeField]
	float speed = 5f;

	void Update()
	{
		target = GetPlayer().transform.position;

		Vector3 currentEnd;
		if (Path.Count > 0)
		{
			currentEnd = Path[Path.Count - 1];
		}
		else
		{
			currentEnd = target + Vector3.one * minRecalcDist * 2f;
		}

		if (Vector3.Distance(target, currentEnd) > minRecalcDist)
		{
			FindPath(transform.position, target);
		}

		Move();
	}

	public new void Move()
	{
		if (Path.Count > 0)
		{
			transform.position = Vector3.MoveTowards(transform.position, Path[0], Time.deltaTime * speed);
			if (Vector3.Distance(transform.position, Path[0]) < 0.4F)
			{
				Path.RemoveAt(0);
			}
		}
	}


	PlayerController GetPlayer()
	{
		return FindObjectOfType<PlayerController>();
	}
}
