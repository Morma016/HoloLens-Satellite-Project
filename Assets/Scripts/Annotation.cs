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

    public void changeHighlightColour(Highlight newHighlightColour)
    {
        // if input colour is not the same as current colour
        if (newHighlightColour != highlightColour)
        {
            highlightColour = newHighlightColour;
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            if(this.GetComponent<Renderer>() != null )
            {
                Color oldColour = originalColour;
                switch (highlightColour)
                {
                    case Highlight.Green:
                        this.GetComponent<Renderer>().material.color = Color.Lerp(oldColour, Color.green, .5f);
                        break;
                    case Highlight.Yellow:
                        this.GetComponent<Renderer>().material.color = Color.Lerp(oldColour, Color.yellow, .5f);
                        break;
                    case Highlight.Red:
                        this.GetComponent<Renderer>().material.color = Color.Lerp(oldColour, Color.red, .5f);
                        break;
                    case Highlight.Blue:
                        this.GetComponent<Renderer>().material.color = Color.Lerp(oldColour, Color.blue, .5f);
                        break;
                    case Highlight.None:
                        this.GetComponent<Renderer>().material.color = oldColour;
                        break;
                }
            }

            // loop through
            foreach (Renderer renderer in renderers)
            {
                Color oldColour = renderer.gameObject.GetComponent<Annotation>().originalColour;

                switch (highlightColour)
                {
                    case Highlight.Green:
                        renderer.material.color = Color.Lerp(oldColour, Color.green, .5f);
                        break;
                    case Highlight.Yellow:
                        renderer.material.color = Color.Lerp(oldColour, Color.yellow, .5f);
                        break;
                    case Highlight.Red:
                        renderer.material.color = Color.Lerp(oldColour, Color.red, .5f);
                        break;
                    case Highlight.Blue:
                        renderer.material.color = Color.Lerp(oldColour, Color.blue, .5f);
                        break;
                    case Highlight.None:
                        renderer.material.color = oldColour;
                        break;
                }
            }
        }
    }

}
