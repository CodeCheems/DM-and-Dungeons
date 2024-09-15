using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class GoldenSkull_TilemapClearer : MonoBehaviour
{
    public bool ClearTilemap = false;

    // Start is called before the first frame update
    void Start()
    {
        Tilemap tilemap = this.GetComponent<Tilemap>();
        if( tilemap != null )
            tilemap.ClearAllTiles();
        DestroyImmediate(this);
    }
    


}
