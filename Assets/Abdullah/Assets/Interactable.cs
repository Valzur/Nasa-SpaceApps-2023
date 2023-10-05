using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    public enum interactable { Box, Sphere,CraftingScreen };
    public interactable CurrentI;
    public abstract void DoSomething();
    private void OnMouseDown()
    {
        DoSomething();
        //Do Somathing
    }

}
