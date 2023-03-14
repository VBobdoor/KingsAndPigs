using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(HealthPoints))]
public class Unit : MonoBehaviour
{
    [SerializeField] private GameObject floatingText;
    [SerializeField] private Transform floatingTextPoint;

    private HealthPoints healthPoints;
    private Animator animator;
    private Rigidbody2D unitRigidbody;
    private string takeDamageVarName = "GetHit";
    private bool damageImmunity = false;
    private float damageImmunityCooldown = 0.5f;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        unitRigidbody = GetComponent<Rigidbody2D>();
        healthPoints = GetComponent<HealthPoints>();
    }

    public void TakeDamage(float damage)
    {
        if (damageImmunity == false)
        {
            if(healthPoints.CurrentHealthPoints - damage <= 0)
            {
                animator.SetBool("Death", true);
            }
            else
            {
                animator.SetTrigger(takeDamageVarName);
            }
            CreateDamageText(damage);
            healthPoints.CurrentHealthPoints -= damage;
            StartCoroutine(SetDamageImmunityOnCoolDown());
        }
    }

    public void knockback(float knockBackForce, bool knockBackDirection)
    {
        if (knockBackDirection)
        {
            unitRigidbody.AddForce(new Vector2(1, 1) * knockBackForce);
        }
        else
        {
            unitRigidbody.AddForce(new Vector2(-1, 1) * knockBackForce);
        }
       
    }

    private void CreateDamageText(float damage)
    {
        GameObject cloneFloatingText = Instantiate(floatingText, floatingTextPoint);
        SetFloatingText cloneSetFloatingText = cloneFloatingText.GetComponentInChildren<SetFloatingText>();
        cloneSetFloatingText.SetText(damage.ToString());
    }

    private IEnumerator SetDamageImmunityOnCoolDown()
    {
        damageImmunity = true;
        yield return new WaitForSeconds(damageImmunityCooldown);
        damageImmunity = false;
    }

}
