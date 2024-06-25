using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{

    private static readonly int Hit = Animator.StringToHash("Hit");
    private static readonly int Die = Animator.StringToHash("Die");

    MonsterController monsterController;
    Animator animator;
    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        monsterController.OnDamaged += Damaged;
        monsterController.Dead += Dead;
        animator = GetComponent<Animator>();
    }
    public void Damaged()
    {
        animator.SetTrigger(Hit);
    }
    public void Dead()
    {
        animator.SetTrigger(Die);
    }
}