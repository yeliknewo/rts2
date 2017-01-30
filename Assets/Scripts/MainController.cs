using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
	Dictionary<LoadedState, List<GameObject>> objects = new Dictionary<LoadedState, List<GameObject>>();

	public void GameLoaded(LoadedState state)
	{
		List<GameObject> targets = objects[state];
		foreach (GameObject target in targets)
		{
			target.SetActive(true);
		}
		targets.Clear();
	}

	public void AddTarget(LoadedState state, GameObject target)
	{
		if (!objects.ContainsKey(state))
		{
			objects.Add(state, new List<GameObject>());
		}
		objects[state].Add(target);
	}
}
