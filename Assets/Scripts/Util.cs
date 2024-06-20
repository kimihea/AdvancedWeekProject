using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Util : MonoBehaviour
{

    public static TilemapRenderer[] GetTilemapRenderersByPath(string path)
    {
        GameObject houseInside = GameObject.Find(path);
        if (houseInside != null)
        {
            return houseInside.GetComponentsInChildren<TilemapRenderer>();
        }
        return new TilemapRenderer[0];
    }

    public static void SetSortingLayer(TilemapRenderer[] renderers, string name)
    {
        foreach (TilemapRenderer renderer in renderers)
        {
            renderer.sortingLayerName = name;
        }
    }
  
}
