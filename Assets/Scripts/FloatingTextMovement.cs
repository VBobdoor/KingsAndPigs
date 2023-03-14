using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextMovement : MonoBehaviour
{
    [SerializeField] private SetFloatingText setFloatingText;

    private float speed = 0.5f;
    private float lifeTime = 1.5f;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        Movement(Time.fixedDeltaTime);
    }

    private void Movement(float deltatime)
    {
        gameObject.transform.position += new Vector3(0, speed * deltatime, 0);
    }

}
