using System.Collections.Generic;

public class Stat
{
	Dictionary<Attributes, float> multipliers = new Dictionary<Attributes, float>();

	float baseLevel;

	public Stat(float newBaseLevel, float strengthMult, float agilityMult, float intelligenceMult)
	{
		baseLevel = newBaseLevel;
		multipliers.Add(Attributes.Strength, strengthMult);
		multipliers.Add(Attributes.Agility, agilityMult);
		multipliers.Add(Attributes.Intelligence, intelligenceMult);
	}

	public float GetCalculatedValue(Dictionary<Attributes, float> attributes)
	{
		return baseLevel + GetStatPart(attributes, Attributes.Strength) + GetStatPart(attributes, Attributes.Agility) + GetStatPart(attributes, Attributes.Intelligence);
	}

	float GetStatPart(Dictionary<Attributes, float> attributes, Attributes attribute)
	{
		return attributes[attribute] * multipliers[attribute];
	}
}
