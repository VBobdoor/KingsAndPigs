using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] GameObject LaserView;

    private float angle = 0;
    private float speedRotation = 35f;
    private float LaserWorkCooldown = 10f;
    private float LaserDisableCooldown = 1f;
    private bool laserOn = false;

    private void Awake()
    {
        StartCoroutine(SetLaserDisableCooldown());
    }

    void FixedUpdate()
    {
        if (laserOn) 
            LaserMove();
        
    }

    private void LaserMove()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        angle -= Time.fixedDeltaTime * speedRotation;
    }

    private IEnumerator SetLaserWorkCooldown()
    {
        laserOn = true;
        LaserView.SetActive(true);
        yield return new WaitForSeconds(LaserWorkCooldown);
        StartCoroutine(SetLaserDisableCooldown());
    }

    private IEnumerator SetLaserDisableCooldown()
    {
        laserOn = false;
        LaserView.SetActive(false);
        yield return new WaitForSeconds(LaserDisableCooldown);
        StartCoroutine(SetLaserWorkCooldown());
    }
    
}
