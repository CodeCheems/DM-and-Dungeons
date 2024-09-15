using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Made by Max Feuerriegel 11-2022
/// For Golden Skull Studios
/// </summary>
[CustomEditor(typeof(GoldenSkull_CustomHandle)), CanEditMultipleObjects]
public class GoldenSkull_CustomHandleEditor : Editor
{
    GoldenSkull_CustomHandle obj;

    private void OnEnable()
    {
        obj = (GoldenSkull_CustomHandle)target;
        obj.Initialize();
        Tools.hidden = true;
    }

    public override void OnInspectorGUI()
    {
        obj.handleUIScale = EditorGUILayout.FloatField("Transform Handle Scale",obj.handleUIScale);
        if( GUILayout.Button("Snap Object to 'Ground'"))
        {
            obj.height = 0;
            obj.transform.position = new Vector3(obj.groundPos.x, obj.groundPos.y, 0);
            //UNDO
            Undo.RecordObject(obj, "Reset Isometric Object Height");
        }
    }

    private void OnDisable()
    {
        Tools.hidden = false;
    }


    private void newHandle()
    {
        //Variables
        obj.groundPos = new Vector3(obj.xyPos.x, obj.xyPos.y, 0);

        //********************************* X Handle
        //x handle
        Handles.color = Color.red;
        obj.groundPos = Handles.Slider(obj.groundPos, new Vector3(1, -0.5f, 0), obj.handleUIScale, Handles.ArrowHandleCap, 0.2f);
        //********************************* Y Handle
        //y handle
        Handles.color = Color.blue;
        obj.groundPos = Handles.Slider(obj.groundPos, new Vector3(-1, -0.5f, 0), obj.handleUIScale, Handles.ArrowHandleCap, 0.2f);

        //********************************* XY Handle
        Handles.color = Color.grey;
        Vector3 freemoveHandleOffset = new Vector3(0, -0.5f*obj.handleUIScale, 0);
        var fmh_57_85_638620362646760900 = Quaternion.Euler(obj.rotation); obj.groundPos = Handles.FreeMoveHandle(obj.groundPos+ freemoveHandleOffset, obj.handleUIScale*0.1f, Vector3.one, Handles.DotHandleCap)- freemoveHandleOffset;

        //********************************* Z Handle
        //variables needed for Z Value
        obj.offset = new Vector3(0, 0, 0);
        obj.newHeight = new Vector3(0, obj.height, 0);
        //z handle
        Handles.color = Color.green;
        obj.newHeight = Handles.Slider(obj.groundPos + obj.newHeight, new Vector3(0, 1f, 0), obj.handleUIScale, Handles.ArrowHandleCap, 0.2f) - obj.groundPos;
        obj.newHeight.z = obj.newHeight.y;

        //********************************* Apply Handle Transforms
        obj.transform.position = new Vector3(obj.groundPos.x, obj.groundPos.y + obj.newHeight.z, obj.newHeight.z * obj.heightMultiplicator);
        Undo.RecordObject(obj, "Isometric transform");
        //Store our new values
        obj.xyPos.x = obj.groundPos.x;
        obj.xyPos.y = obj.groundPos.y;
        obj.height = obj.newHeight.z;
        //
        obj.UpdateObject();
        //UNDO
        Undo.RecordObject(obj, "Isometric transform");
    }

    void OnSceneGUI()
    {
        newHandle();
    }
}


 