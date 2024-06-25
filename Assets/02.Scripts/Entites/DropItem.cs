using System.Collections;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject Item;
    public Transform dropPosition;
    public int amount;
    public int additionalAmout;
    public float spawnRadius = 1f;

    public void Drop()
    {
        StartCoroutine(DropItems());
    }
    IEnumerator DropItems()
    {
        additionalAmout = GameManager.Instance.nowData.nowStage;
        for (int i = 0; i < amount+ additionalAmout; i++)
        {
            
            Vector2 randomPosition = dropPosition.position + (Vector3)Random.insideUnitCircle * spawnRadius;
            Instantiate(Item, randomPosition, Quaternion.identity);
            
        }
        yield return null;
    }
}