using InventorySystem;
using ResourcesSystem;

public static class CraftingManager
{
	public static bool TryCraft(Recipe recipe, out Item output)
	{
		if(!AreRequirementsFullfilled(recipe))
		{
			output = Item.Empty;
			return false;
		}

		PayRecipeCost(recipe);
		output = new Item(recipe.Output);
		return true;
	}

	public static bool AreRequirementsFullfilled(Recipe recipe)
	{
		foreach (Requirement requirement in recipe.requirements)
		{
			if(Resources.CountOf(requirement.Resource) <= requirement.Count)
			{
				return false;
			}
		}

		return true;
	}

	public static void PayRecipeCost(Recipe recipe)
	{
		foreach (Requirement requirement in recipe.requirements)
		{
			Resources.Consume(requirement.Resource, requirement.Count);
		}
	}
}
