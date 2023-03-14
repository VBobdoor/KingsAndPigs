using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnTouch : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float knockBackForce;

    private Collider2D attackCollider;
    

    private void Awake()
    {
        attackCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.GetComponentInParent<Unit>();
        unit.TakeDamage(damage);
        unit.knockback(knockBackForce, false);
    }

}
