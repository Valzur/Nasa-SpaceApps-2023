using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingScreen : Interactable
{
    public Dropdown ChooseRecipe;
    Button StartPlacingBtn;
    private void Start()
    {
        StartPlacingBtn = GameObject.Find("StartPlacingBtn").GetComponent<Button>();
        foreach (Recipe recipe in Recipe.All)
        {
            ChooseRecipe.options.Add(new Dropdown.OptionData(recipe.Output.name, recipe.Output.icon));
        }
        ChooseRecipe.gameObject.transform.parent.gameObject.SetActive(false);

    }


    private void Update()
    {
        if (ChooseRecipe.value > 0 && CraftingManager.AreRequirementsFullfilled(Recipe.All[ChooseRecipe.value - 1])) 
        {
            StartPlacingBtn.interactable = true;
        }
        else
        {
            StartPlacingBtn.interactable = false;
        }
    }
    public override void DoSomething()
    {
        ChooseRecipe.gameObject.transform.parent.gameObject.SetActive(true);
    }

    public void PlaceObject()
    {
        Tooltip.IsAbleToPlace = true;
        CraftingManager.PayRecipeCost(Recipe.All[ChooseRecipe.value - 1]);
    }

}
