using System;
using ResourcesSystem;
using UnityEngine;

public class ResourcesManagerUI : MonoBehaviour
{
	[SerializeField] SingleResourceUI resourceUIPrefab;
	[SerializeField] Transform resourcesParent;

	void Awake()
	{
		foreach (object resourceValue in Enum.GetValues(typeof(Resource)))
		{
			Instantiate(resourceUIPrefab, resourcesParent).Bind((Resource)resourceValue);
		}
	}
}
