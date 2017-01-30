using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	[SerializeField]
	GameObject wallPrefab;

	[SerializeField]
	GameObject goldPrefab;

	[SerializeField]
	GameObject basePrefab;

	[SerializeField]
	GameObject minLocation;

	[SerializeField]
	GameObject maxLocation;

	[SerializeField]
	float xStepsDiv = 1;

	[SerializeField]
	float zStepsDiv = 1;

	[SerializeField]
	int wallTarget = 1;

	[SerializeField]
	int goldTarget = 1;

	[SerializeField]
	int baseTarget = 1;

	[SerializeField]
	int wallGenChance = 1;

	[SerializeField]
	int goldGenChance = 1;

	[SerializeField]
	int baseGenChance = 1;

	GameObject wallParent;
	GameObject goldParent;
	GameObject baseParent;

	void Awake()
	{
		Generate();
	}

	void Generate()
	{
		wallParent = new GameObject();
		wallParent.name = "WallParent";
		wallParent.transform.parent = transform;

		goldParent = new GameObject();
		goldParent.name = "GoldParent";
		goldParent.transform.parent = transform;

		baseParent = new GameObject();
		baseParent.name = "BaseParent";
		baseParent.transform.parent = transform;

		int xLength = Mathf.RoundToInt((maxLocation.transform.position.x - minLocation.transform.position.x) / xStepsDiv);
		int zLength = Mathf.RoundToInt((maxLocation.transform.position.z - minLocation.transform.position.z) / zStepsDiv);

		List<Vector2> locations = new List<Vector2>();

		for (int z = 0; z < zLength; z++)
		{
			for (int x = 0; x < xLength; x++)
			{
				locations.Add(new Vector2(x, z));
			}
		}

		while (locations.Count > 0)
		{
			int index = Random.Range(0, locations.Count - 1);
			Vector2 location = locations[index];
			locations.RemoveAt(index);

			int x = Mathf.RoundToInt(location.x);
			int z = Mathf.RoundToInt(location.y);

			Transform parent = transform;
			GameObject targetPrefab = null;
			if (Random.Range(0, wallGenChance) <= wallTarget)
			{
				wallTarget -= 1;
				targetPrefab = wallPrefab;
				parent = wallParent.transform;
			}
			else if (Random.Range(0, goldGenChance) <= goldTarget)
			{
				goldTarget -= 1;
				targetPrefab = goldPrefab;
				parent = goldParent.transform;
			}
			else if (Random.Range(0, baseGenChance) <= baseTarget)
			{
				baseTarget -= 1;
				targetPrefab = basePrefab;
				parent = baseParent.transform;
			}

			if (targetPrefab != null)
			{
				Instantiate(targetPrefab, new Vector3(x * xStepsDiv + minLocation.transform.position.x, 0.5f, z * zStepsDiv + minLocation.transform.position.z), transform.rotation, parent);
			}
		}
	}
}
