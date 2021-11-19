using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KnifeandBoss" , menuName = "KnifeandBoss")]
public class KnifeandBoss : ScriptableObject
{
    [SerializeField]
    private GameObject[] knife;

    [SerializeField]
    private GameObject[] boss;

    [SerializeField]
    private int[] knifeCount;

    public GameObject GetKnife(int i)
    {
        return knife[i];
    }

    public GameObject GetBoss(int i)
    {
        return boss[i];
    }

    public int GetKnifeCount(int i)
    {
        return knifeCount[i];
    }
}
