using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
public enum InteriorType
{
    workBench,
    chest,
    trophy
}
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
        //OnPlayerInteract Add action+=Interact();
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
    private void Interact(Interior interior)
    {
        if (interior.interiorType == InteriorType.trophy) return;
        if (interior.interiorType == InteriorType.chest)
        {
            //open chest's inventory and player's inventory
        }
        if (interior.interiorType == InteriorType.workBench)
        {
            //show what can do on workBench
        }

    }
}