using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    void OnMouseDown() => OnInteract();

    protected virtual void OnInteract(){}
}
