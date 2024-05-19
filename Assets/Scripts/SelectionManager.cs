using Microsoft.MixedReality.GraphicsTools;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityFx.Outline;

/// <summary>
/// This class is a non monobehaviour singleton that manages
/// selections.
/// </summary>
public class SelectionManager : Singleton<SelectionManager>
{
	
    public static Explodable currentSelection;
    private List<Subscriber> subscribers = new List<Subscriber>();

    /// <summary>
    /// Sets the current selection.
    /// </summary>
    /// <param name="interactable"> the interactable</param>
    public void setSelection(Explodable interactable)
    {
        if(interactable == null)
        {
            Debug.Log("Cannot make selection as the iteractable is null");
            return;
        }

        // handle outline swapping, MODEL NEEDS READ/WRITE ENABLED MESH for nicer looking outline
        if(interactable != currentSelection)
        {
            if(currentSelection != null)
            {
                // disable previous selection outline
                currentSelection.GetComponent<MeshOutlineHierarchy>().enabled = false;
            }

            MeshOutlineHierarchy newSelectionOutline = interactable.GetComponent<MeshOutlineHierarchy>();

            // if new selected object hasn't had meshoutline generated create new one
            if (newSelectionOutline == null)
            {
                Material material = Resources.Load<Material>("MRTK_Outline_Blue");
                MeshOutlineHierarchy newOutline = interactable.AddComponent<MeshOutlineHierarchy>();
                newOutline.OutlineMaterial = material;
            }
            else
            {
                // else if it already has one, just enable it
                newSelectionOutline.enabled = true;
            }
        }

        if(currentSelection == null)
        {

        }

        currentSelection = interactable;
        Debug.Log($"Current selection is {interactable.name}");

        foreach(Subscriber subscriber in subscribers)
        {
            subscriber.UpdateSubscriber(currentSelection);
        }
    }

    /// <summary>
    /// resets the current selection
    /// *might not be needed but is here for debugging*
    /// </summary>
    public void deactivateSelection() 
    {
        if(currentSelection == null) 
        {
            Debug.Log("Cannot make deselect as the current selection is already null");
            return;
        }
        Debug.Log($"Deselected {currentSelection.transform.gameObject.name}");
        currentSelection = null;
        
    }

    public void addSubscriber(Subscriber newSubscriber)
    {
        subscribers.Add(newSubscriber);
    }
    
}
