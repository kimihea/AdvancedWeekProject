using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateController : MonoBehaviour
{
    GameManager gm => GameManager.Instance ;
    public float difficulty;
    public float cure=0f;
    public void Update()
    {
        gm.nowData.fatigue += Time.deltaTime * (difficulty+cure);
        if (gm.nowData.maxFatigue <= gm.nowData.fatigue)
        {
            gm.TheEnd();
            Time.timeScale = 0;
        }
    }
    public void EnterDungeon()
    {
        gm.nowData.fatigue += 10f;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("CureHouse"))
            StartCoroutine(EnterCure());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        return;
    }
    
    public IEnumerator EnterCure()
    {
        if (gm.nowData.Gold >= 5)
        {
            gm.PlaySFX(SFXEnum.HEAL);
            gm.nowData.Gold -= 5;
            cure = -10f;
            yield return new WaitForSeconds(2);
            cure = 0f;
        }
        else 
        {
            gm.ShowAlert("골드부족");
            yield return null;
        }
        
    }
    
}