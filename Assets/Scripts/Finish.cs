using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private Animator animator;
    private bool closeToGoIn;
    private static string animationVarOpen = "Open";
    private static string animationVarClose = "Close";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenDoor();
        closeToGoIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CloseDoor();
        closeToGoIn = false;
    }

    private void Update()
    {
        if(Input.GetAxisRaw(GlobalStringVars.VERTICAL_AXIS) > 0)
        {
            GoToNextLevel();
        }
    }

    private void OpenDoor()
    {
        animator.SetTrigger(animationVarOpen);
    }

    private void CloseDoor()
    {
        animator.SetTrigger(animationVarClose);
    }

    public void GoToNextLevel()
    {
        if(closeToGoIn)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
