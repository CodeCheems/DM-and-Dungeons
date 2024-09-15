using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class GoldenSkull_ColorLayers : MonoBehaviour
{
    [SerializeField] public GoldenSkull_ColorLayerObject[] Layerobjects;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateLayers()
    {
        foreach (GoldenSkull_ColorLayerObject layerobj in Layerobjects)
        {
            foreach (UnityEngine.Tilemaps.Tilemap layer in layerobj.Layers)
            {
                layer.color = layerobj.Layercolor;
            }
        }
    }

}

[System.Serializable]
public struct GoldenSkull_ColorLayerObject
{
    [SerializeField] public Color Layercolor;
    [SerializeField] public UnityEngine.Tilemaps.Tilemap[] Layers;
}
