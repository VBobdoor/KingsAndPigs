using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootCoolDown;
    [SerializeField] private float bulletShootPower;

    private const string ANIMATOR_VAR_SHOOT = "Shoot";
    private Animator animator;
    private bool AbleToShoot = true;

    private void Update()
    {
        if (AbleToShoot == true)
            Shoot();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Shoot()
    {
        CreateBulletAndGiveSpeed();
        animator.SetTrigger(ANIMATOR_VAR_SHOOT);
        StartCoroutine(SetShootCoolDown());
    }

    private void CreateBulletAndGiveSpeed()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
        currentBulletVelocity.velocity = new Vector2(bulletShootPower, currentBulletVelocity.velocity.y);
    }

    private IEnumerator SetShootCoolDown()
    {
        AbleToShoot = false;
        yield return new WaitForSeconds(shootCoolDown);
        AbleToShoot = true;
    }

}
