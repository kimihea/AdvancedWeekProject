 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonUI : MonoBehaviour
{
    public static DungeonUI Instance;
    GameManager gm => GameManager.Instance;
    public ParticleSystem EffectParticle;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject); 
        }
        Instance = this;

        EffectParticle = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
    }
    private void Start()
    {
        gm.FadeIn();
        gm.PlayBGM(BGMEnum.Dungeon);
    }
    public void MoveMain()
    {
        gm.MoveScene(1);
        gm.PlaySFX(SFXEnum.UI_CLICK);
    }
    

}
