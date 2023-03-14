using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] float maxHealthPoints;
    [SerializeField] private float currentHealthPoints;

    public float CurrentHealthPoints
    {
        get 
        {
            return currentHealthPoints;
        }
        set 
        {       
            if (value <= 0)
            {
                currentHealthPoints = value;
                Deth();
            }
            else 
            {
                currentHealthPoints = value;
            }
        }
    }

    private void Awake()
    {
        currentHealthPoints = maxHealthPoints;
    }

    public void SetMaxHealth(float newMaxHealthPoints)
    {
        maxHealthPoints = newMaxHealthPoints;
    }

    public float GetMaxHealth()
    {
        return maxHealthPoints;
    }

    private void Deth()
    {
        Destroy(gameObject, 1);
    }

    
}
