using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text tooltipText;
    public static Interactable Current;
    void Start()
    {
        HideTooltip();
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        // Convert screen position to world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // Set the tooltip position to the world position
        //tooltipText.transform.position = worldPosition;

        // Raycast to detect objects under the cursor
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            TooltipDescription tooltipDescription;
            // Check if the object has a tooltip description
            if (hit.collider.GetComponent<TooltipDescription>() != null)
            {
                if (hit.collider.GetComponent<Interactable>() != null)
                {
                    Current = hit.collider.GetComponent<Interactable>();
                }
                tooltipDescription = hit.collider.GetComponent<TooltipDescription>();
                if (tooltipDescription != null)
                {
                    // Show the tooltip and update its content
                    ShowTooltip();
                    tooltipText.text = tooltipDescription.description;
                }
                else
                {
                    // Hide the tooltip if no description found
                    HideTooltip();
                }
            }
            else
            {
                // Hide the tooltip if no object detected
                HideTooltip();
            }

        }
        
    }

    void ShowTooltip()
    {
        tooltipText.GetComponent<Text>().enabled = true;
    }

    void HideTooltip()
    {
        tooltipText.GetComponent<Text>().enabled = false;
    }
}