using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class GoldenSkull_CustomHandle : MonoBehaviour
{
    //public Vector3 PivotOffset;
    public Vector3 rotation = new Vector3(22.5f,132.5f,-22.5f);

    public Vector2 xyPos;
    public float height = 0;

    public Vector3 groundPos;
    public Vector3 actualPos;
    public Vector3 offset;
    public Vector3 newHeight;

    private bool initialized = false;

    public float heightMultiplicator = 5;

    public void Initialize()
    {
        //initialize only for objects that haven't been initialized before, so make sure they don't snap to 0,0,0
        if( !initialized )
        {
            groundPos = this.transform.position;
            groundPos.z = 0;
            height = 0;
            initialized = true;
        }
    }

    //UI based
    public float handleUIScale = 1;

    private SpriteRenderer m_spriteRenderer;
    public void UpdateObject()
    {
        if (m_spriteRenderer == null)
        {
            m_spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        }
        else
        {
            if( m_spriteRenderer.spriteSortPoint != SpriteSortPoint.Pivot )
                m_spriteRenderer.spriteSortPoint = SpriteSortPoint.Pivot;
        }
    }
}
