using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimationMachine))]
public class PlayerSeatAndGoThroughPlatform : MonoBehaviour
{
    [SerializeField] private int ignoreOneWayPlarformLayerValue;
    [SerializeField] private int defaultLayerValue;
    [SerializeField] private GameObject CollideWithPlatformsPart;
   
    private AnimationMachine animationMachine;
    
    private void Awake()
    {
        animationMachine = GetComponent<AnimationMachine>();

    }

    public void Seat()
    {
        animationMachine.SetSeatAnimation();
    }

    public void GoThroughPlatform()
    {
        CollideWithPlatformsPart.layer = ignoreOneWayPlarformLayerValue;
        StartCoroutine(timerSetLayerBack());
    }

    private IEnumerator timerSetLayerBack()
    {
        yield return new WaitForSeconds(0.5f);
        CollideWithPlatformsPart.layer = defaultLayerValue;
    }
}
