using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnotationManager : MonoBehaviour
{
    public GameObject allModelObjects;

    // Start is called before the first frame update
    void Start()
    {
        // Loop over all models
        foreach (Transform modelTransform in allModelObjects.transform)
        {
            Annotation annotation = modelTransform.gameObject.AddComponent<Annotation>();
            Renderer renderer = modelTransform.gameObject.GetComponent<Renderer>();
            if ( renderer != null )
            {
                annotation.originalColour = renderer.material.color;
            }
            initialiseAnnotations(modelTransform);
        }

    }

    void initialiseAnnotations(Transform modelTransform)
    {
        foreach(Transform subTransform in modelTransform)
        {
            Annotation annotation = subTransform.gameObject.AddComponent<Annotation>();
            Renderer renderer = subTransform.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                annotation.originalColour = renderer.material.color;
            }
            initialiseAnnotations(subTransform);
        }
    }

   /* public void changeHighlight(Annotation.Highlight newColour)
    {
        Explodable changedObject = SelectionManager.currentSelection;
        changedObject.GetComponent<Annotation>().changeHighlightColour(newColour);
    }*/

    public void changeHighlightNone()
    {
        Explodable changedObject = SelectionManager.currentSelection;
        changedObject.GetComponent<Annotation>().changeHighlightColour(Annotation.Highlight.None);
    }

    public void changeHighlightRed()
    {
        Explodable changedObject = SelectionManager.currentSelection;
        changedObject.GetComponent<Annotation>().changeHighlightColour(Annotation.Highlight.Red);
    }

    public void changeHighlightBlue()
    {
        Explodable changedObject = SelectionManager.currentSelection;
        changedObject.GetComponent<Annotation>().changeHighlightColour(Annotation.Highlight.Blue);
    }
}
