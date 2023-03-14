using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Slider))]
public class HealthBarSliderController : MonoBehaviour
{
    [SerializeField] private HealthPoints healthPoints;
    [SerializeField] private GameObject loseScreen;
    private Slider slider;
   


    private void Awake()
    {
        slider = GetComponent<Slider>();
        SetMaxHealth(healthPoints.GetMaxHealth());
    }

    private void Update()
    {
        SetHealth(healthPoints.CurrentHealthPoints);
        if(healthPoints.CurrentHealthPoints <= 0)
        {
            GameOver();
        }
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    private void GameOver()
    {
        loseScreen.SetActive(true);
    }   

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
