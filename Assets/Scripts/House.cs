using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

class House : MonoBehaviour
{
    [Header("houseInfo")]
    [SerializeField] string HousePath;
    [SerializeField] string exposeLayer = "ExposeHouse";
    [SerializeField] string maskLayer = "MaskHouse";

    TilemapRenderer[] houseTilemapRenderers;
    private void Awake()
    {
        PlayerExit();
    }
    private void PlayerEnter()
    {
        houseTilemapRenderers = Util.GetTilemapRenderersByPath(HousePath);
        Util.SetSortingLayer(houseTilemapRenderers, exposeLayer);
    }
    private void PlayerExit()
    {
        houseTilemapRenderers = Util.GetTilemapRenderersByPath(HousePath);
        Util.SetSortingLayer(houseTilemapRenderers, maskLayer);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerEnter();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExit();
        }
    }
}