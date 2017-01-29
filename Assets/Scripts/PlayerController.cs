using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : Hero
{
	[SerializeField]
	GameObject prefabProjectile;

	[SerializeField]
	float strength;

	[SerializeField]
	float agility;

	[SerializeField]
	float intelligence;

	[SerializeField]
	float accelerationMultiplier;

	[SerializeField]
	float baseShotCooldown;

	float lastShotTime;

	private void OnEnable()
	{
		SetupAttributes();
	}

	void Update()
	{
		strength = GetStrength();
		agility = GetAgility();
		intelligence = GetIntelligence();

		float xAxis = Input.GetAxis(InputManager.AXIS_X);
		float zAxis = Input.GetAxis(InputManager.AXIS_Y);

		GetRigidbody().velocity = Utilities.UseDrag(GetRigidbody().velocity, Mathf.Abs(xAxis) < Mathf.Abs(GetRigidbody().velocity.x / GetWalkSpeed()), Mathf.Abs(zAxis) < Mathf.Abs(GetRigidbody().velocity.z / GetWalkSpeed()), GetWalkSpeedDrag());

		GetRigidbody().AddForce(new Vector3(
			Utilities.GetSpeed(xAxis, GetRigidbody().velocity.x, GetWalkSpeed()),
			0,
			Utilities.GetSpeed(zAxis, GetRigidbody().velocity.z, GetWalkSpeed())
			) * accelerationMultiplier, ForceMode.Acceleration);

		if (Input.GetMouseButton(InputManager.BUTTON_MOUSE_LEFT))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		if (CanShoot())
		{
			GameObject projectile = Instantiate<GameObject>(prefabProjectile, transform.position, transform.rotation, transform);
			projectile.GetComponent<Rigidbody>().velocity = (GetCamera().transform.position - transform.position) * GetProjectileSpeed();
			//projectile.GetComponent<ProjectileController>().SetRange(GetRange());
			lastShotTime = Time.time;
		}
	}

	bool CanShoot()
	{
		return lastShotTime < Time.time - baseShotCooldown / GetShotCooldown();
	}

	Rigidbody GetRigidbody()
	{
		return GetComponent<Rigidbody>();
	}

	Camera GetCamera()
	{
		return FindObjectOfType<Camera>();
	}
}
