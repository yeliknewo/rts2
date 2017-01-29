using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
	List<GameObject> targets = new List<GameObject>();
	List<GameObject> pathfinders = new List<GameObject>();

	LoadedState state = LoadedState.None;

	public void GameLoaded(LoadedState state)
	{
		this.state = state;
	}

	private void Update()
	{
		if (state == LoadedState.MapGen || state == LoadedState.Pathfinding)
		{
			foreach (GameObject pathfinder in pathfinders)
			{
				pathfinder.SetActive(true);
			}
			pathfinders.Clear();
		}
		if (state == LoadedState.Pathfinding)
		{
			foreach (GameObject target in targets)
			{
				target.SetActive(true);
			}
			targets.Clear();
		}
	}

	public void AddPathfinder(GameObject pathfinder)
	{
		pathfinders.Add(pathfinder);
	}

	public void AddTarget(GameObject target)
	{
		targets.Add(target);
	}
}
