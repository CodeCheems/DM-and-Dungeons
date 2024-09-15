using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GoldenSkull_ColorLayers))]
public class GoldenSkull_ColorLayersEditor : Editor
{
    private bool toggleLayerUpdate = false;
    public override void OnInspectorGUI()
    {
        GoldenSkull_ColorLayers myTarget = (GoldenSkull_ColorLayers)target;
        if (toggleLayerUpdate = GUILayout.Toggle(toggleLayerUpdate,"Update Layers", "Button"))
        {
            myTarget.UpdateLayers();
        }
        base.DrawDefaultInspector();

        //EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
    }
}