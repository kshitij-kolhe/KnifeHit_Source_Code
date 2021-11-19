using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    private int usedKnifeCount = 0;

    [SerializeField]
    private GameObject restartButton;

    [SerializeField]
    private GameObject knifePanel;
    [SerializeField]
    private GameObject knifeIcon;
    [SerializeField]
    private Color usedKnifeColor;

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void DisplayInitialKnifeIcons(int count)
    {
        usedKnifeCount = 0;

        for(int i=0; i<knifePanel.transform.childCount;i++)
        {
            Destroy(knifePanel.transform.GetChild(i).gameObject);
        }

        for(int i=0;i<count;i++)
        {
            Instantiate(knifeIcon, knifePanel.transform);
        }
    }
    
    public void DecrementKnifeIcon()
    {
        knifePanel.transform.GetChild(usedKnifeCount++).GetComponent<Image>().color = usedKnifeColor;
    }


}
