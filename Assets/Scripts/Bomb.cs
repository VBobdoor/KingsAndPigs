using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float boomTime;
    private Animator animator;
    private Rigidbody2D bombRigidbody;

    private void Awake()
    {
        bombRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(BoomTimer());
    }

    private IEnumerator BoomTimer()
    {
        yield return new WaitForSeconds(boomTime);
        bombRigidbody.freezeRotation = true;
        animator.SetTrigger("Boom");
        Destroy(gameObject, 1f);
    }
}
