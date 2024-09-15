using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class GoldenSkull_TilemapHelper : MonoBehaviour
{
    public bool ClearTilemap = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( ClearTilemap)
        {
            Tilemap tilemap = this.GetComponent<Tilemap>();
            if( tilemap != null )
                tilemap.ClearAllTiles();
            ClearTilemap = false;
        }
    }
    


}
