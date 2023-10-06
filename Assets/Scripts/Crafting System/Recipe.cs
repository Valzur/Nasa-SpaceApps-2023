using System;
using InventorySystem;
using ResourcesSystem;
using UnityEngine;

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
	public static Recipe[] All => UnityEngine.Resources.LoadAll<Recipe>("Recipes");
	public PlaceableItem Output;
	public Requirement[] requirements;
}


[Serializable]
public struct Requirement
{
	public Resource Resource;
	public int Count;
}
