using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityFx.Outline;

public class OutlineManager : MonoBehaviour
{
    public GameObject outlineThis;
    public Camera thisIsCamera;
    private OutlineResources outlineResources = new OutlineResources();

    // Start is called before the first frame update
    void Start()
    {
        var outlineEffect = thisIsCamera.GetComponent<OutlineEffect>();
        var layer = new OutlineLayer("Outlines");

        layer.OutlineColor = Color.blue;
        layer.OutlineWidth = 7;
        layer.OutlineRenderMode = OutlineRenderFlags.Blurred;
        layer.Add(outlineThis);

        outlineEffect.OutlineLayers.Add(layer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
