using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	Dictionary<Attributes, float> attributes = new Dictionary<Attributes, float>();

	Stat walkSpeed = new Stat(10f, 0.1f, 1f, 0.1f);
	Stat walkSpeedDrag = new Stat(10f, 0.1f, 1f, 0.1f);
	Stat projectileSpeed = new Stat(8f, 0.5f, 0.05f, 0.05f);
	Stat range = new Stat(1f, 0.1f, 0.1f, 0.5f);
	Stat shotCooldown = new Stat(1.0f, 0f, 0f, 0.05f);

	protected float GetWalkSpeed()
	{
		return walkSpeed.GetCalculatedValue(attributes);
	}

	protected float GetWalkSpeedDrag()
	{
		return walkSpeedDrag.GetCalculatedValue(attributes);
	}

	protected float GetProjectileSpeed()
	{
		return projectileSpeed.GetCalculatedValue(attributes);
	}

	protected float GetRange()
	{
		return range.GetCalculatedValue(attributes);
	}

	protected float GetShotCooldown()
	{
		return shotCooldown.GetCalculatedValue(attributes);
	}

	protected float GetStrength()
	{
		return GetAttribute(Attributes.Strength);
	}

	protected float GetAgility()
	{
		return GetAttribute(Attributes.Agility);
	}

	protected float GetIntelligence()
	{
		return GetAttribute(Attributes.Intelligence);
	}

	protected float GetAttribute(Attributes attribute)
	{
		return attributes[attribute];
	}

	protected void SetStrength(float val)
	{
		SetAttribute(Attributes.Strength, val);
	}

	protected void SetAgility(float val)
	{
		SetAttribute(Attributes.Agility, val);
	}

	protected void SetIntelligence(float val)
	{
		SetAttribute(Attributes.Intelligence, val);
	}

	protected void SetAttribute(Attributes attribute, float val)
	{
		attributes[attribute] = val;
	}

	protected void SetupAttributes()
	{
		if(!attributes.ContainsKey(Attributes.Strength))
		{
			attributes.Add(Attributes.Strength, 0);
		}
		if (!attributes.ContainsKey(Attributes.Agility))
		{
			attributes.Add(Attributes.Agility, 0);
		}
		if (!attributes.ContainsKey(Attributes.Intelligence))
		{
			attributes.Add(Attributes.Intelligence, 0);
		}
	}
}
