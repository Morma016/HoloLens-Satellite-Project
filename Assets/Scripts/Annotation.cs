using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annotation : MonoBehaviour
{
    public Highlight highlightColour = Highlight.None;
    public Color originalColour;

    public enum Highlight
    {
        Green,
        Yellow,
        Red,
        Blue,
        None
    }

    public void setHighlight(Highlight highlight)
    {
        this.highlightColour = highlight;
        if (this.GetComponent<Renderer>() != null)
        {
            switch (highlightColour)
            {
                case Highlight.Green:
                    this.GetComponent<Renderer>().material.color = Color.Lerp(originalColour, Color.green, .5f);
                    break;
                case Highlight.Yellow:
                    this.GetComponent<Renderer>().material.color = Color.Lerp(originalColour, Color.yellow, .5f);
                    break;
                case Highlight.Red:
                    this.GetComponent<Renderer>().material.color = Color.Lerp(originalColour, Color.red, .5f);
                    break;
                case Highlight.Blue:
                    this.GetComponent<Renderer>().material.color = Color.Lerp(originalColour, Color.blue, .5f);
                    break;
                case Highlight.None:
                    this.GetComponent<Renderer>().material.color = originalColour;
                    break;
            }
        }
    }

    public void changeHighlightColour(Highlight newHighlightColour)
    {
        highlightColour = newHighlightColour;
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        if(this.GetComponent<Renderer>() != null )
        {
            this.setHighlight(newHighlightColour);
        }

        // loop through
        foreach (Renderer renderer in renderers)
        {
            renderer.gameObject.GetComponent<Annotation>().setHighlight(highlightColour);
        }
    }

}
