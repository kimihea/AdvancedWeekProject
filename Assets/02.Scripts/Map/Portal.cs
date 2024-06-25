using UnityEngine;

public class Portal: MonoBehaviour 
{
    CircleCollider2D exit;
    public string targetTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameObject go = GameObject.FindGameObjectWithTag(targetTag);
            if (go == null)
            {
                GameManager.Instance.nowData.nowStage++;
            }
            GameManager.Instance.SaveGame();
            GameManager.Instance.MoveScene(1);
        }
       
        
    }
}
