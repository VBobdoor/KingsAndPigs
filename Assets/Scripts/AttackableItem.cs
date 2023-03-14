using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AttackableItem : MonoBehaviour
{
    private Rigidbody2D itemRigidbody;
    private float powerMultiplayer = 3f;

    private void Awake()
    {
        itemRigidbody = GetComponent<Rigidbody2D>();
    }

    public void knockback(float knockBackForce, bool knockBackDirection)
    {
        if (knockBackDirection)
        {
            itemRigidbody.AddForce(new Vector2(1, 1) * knockBackForce * powerMultiplayer);
        }
        else
        {
            itemRigidbody.AddForce(new Vector2(-1, 1) * knockBackForce * powerMultiplayer);
        }

    }
}
