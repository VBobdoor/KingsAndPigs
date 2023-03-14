using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondBar : MonoBehaviour
{
    static public DiamondBar diamondBar;
    private int diamondCount = 0;
    private Text diamondsText;

    private void Awake()
    {
        if (diamondBar == null)
        {
            diamondBar = this;
        }
        else
        {
            Debug.Log("2 diamond bars");
        }

        diamondsText = GetComponentInChildren<Text>();
        diamondTextRefresh();
    }

    public void diamondPlus(int diamonds)
    {
        diamondCount += diamonds;
        diamondTextRefresh();
    }

    private void diamondTextRefresh()
    {
        diamondsText.text = diamondCount.ToString() + " X";
    }

}
