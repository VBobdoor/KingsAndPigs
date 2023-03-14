using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _UI;
    [SerializeField] private GameObject bossUI;
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private PlayerInput playerInput;

    private bool isPlayed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayed == false)
        {
            isPlayed = true;
            startCutScene();
        }
    }

    public void Deactivate()
    {
        playerInput.startMove();
        _UI.SetActive(true);
        bossUI.SetActive(true);
        playableDirector.Stop();

    }

    private void startCutScene()
    {
        playerInput.stopMove();
        _UI.SetActive(false);
        playableDirector.Play();
    }
}
