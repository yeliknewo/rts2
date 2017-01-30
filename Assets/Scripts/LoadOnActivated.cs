using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnActivated : MonoBehaviour
{
	[SerializeField]
	LoadedState state = LoadedState.None;

	bool trigger = false;

	private void OnEnable()
	{
		if (trigger)
		{
			GetMainController().GameLoaded(state);
			Destroy(this);
		}
		else
		{
			trigger = true;
		}
	}

	MainController GetMainController()
	{
		return FindObjectOfType<MainController>();
	}
}
