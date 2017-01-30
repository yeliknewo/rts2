using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnLoaded : MonoBehaviour
{
	[SerializeField]
	LoadedState state = LoadedState.None;

	private void Awake()
	{
		GetMainController().AddTarget(state, gameObject);
		gameObject.SetActive(false);
		Destroy(this);
	}

	MainController GetMainController()
	{
		return FindObjectOfType<MainController>();
	}
}
