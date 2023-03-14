using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("Taken", true);
    }

    public void Disappear()
    {
        increaseDiamondsCount(1);
        Destroy(gameObject);
    }

    private void increaseDiamondsCount(int diamonds)
    {
        DiamondBar.diamondBar.diamondPlus(diamonds);
    }
}
