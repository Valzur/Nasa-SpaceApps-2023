using UnityEngine;

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
