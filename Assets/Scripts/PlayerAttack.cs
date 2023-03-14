using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AnimationMachine))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPointRight;
    [SerializeField] private Transform attackPointLeft;
    [SerializeField] private float attackColliderRadius = 0.8f;
    [SerializeField] private LayerMask enemyMask;

    private float damage = 25;
    private AnimationMachine animationMachine;
    private float AttackCooldown = 0.5f;
    private bool AbleToAttack = true;
    private float knockBackForce = 100;
     
    private void Awake()
    {
        animationMachine = GetComponent<AnimationMachine>();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPointLeft.position, attackColliderRadius);
        Gizmos.DrawWireSphere(attackPointRight.position, attackColliderRadius);
    }   

    public void Attack()
    {
        if (AbleToAttack)
        {
            animationMachine.SetAttackAnimation();
            HitEnemysInCircle();
            StartCoroutine(SetAttackCooldown());
        }
    }

    private void HitEnemysInCircle()
    {
        Transform attackPoint;
        attackPoint = GetViewDirection();
        

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackColliderRadius, enemyMask);

        foreach (Collider2D enemy in hitEnemys)
        {
            if (enemy.TryGetComponent(out Unit unit))
                AttackUnit(unit);
            else if (enemy.TryGetComponent(out AttackableItem attackableItem))
                AttackItem(attackableItem);
            else if (enemy.TryGetComponent(out Box box))
                box.TakeDamage();
        }
    }

    private void AttackUnit(Unit unit)
    {
        unit.TakeDamage(damage);
        if (unit.TryGetComponent(out Rigidbody2D rb))
        {
            unit.knockback(knockBackForce, animationMachine.CheckViewDirection());
        }
    }

    private void AttackItem(AttackableItem attackableItem)
    {
        attackableItem.knockback(knockBackForce, animationMachine.CheckViewDirection());
    }
    
    private Transform GetViewDirection()
    {
        if (animationMachine.CheckViewDirection())
        {
            return attackPointRight;
        }
        else
        {
            return attackPointLeft;
        }
    }

    private IEnumerator SetAttackCooldown()
    {
        AbleToAttack = false;
        yield return new WaitForSeconds(AttackCooldown);
        AbleToAttack = true;
    }

}
