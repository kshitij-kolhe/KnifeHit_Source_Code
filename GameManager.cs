using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(GameUi))]
public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField]
    private LogMotor logMotor;

    private GameObject Knife;
    private GameObject Boss;

    [Header("Knife and Boss")]
    [SerializeField]
    private Vector2 bossSpawnPosition;
    [SerializeField]
    private Vector2 knifeSpawnPosition;
    [SerializeField]
    private KnifeandBoss knifeandBoss;
    
    private int knifeCount = 0;
    private int count = 0;

    public GameUi gameUi { get; private set; }

    private void Awake()
    {
        Instance = this;
        gameUi = GetComponent<GameUi>();

        Knife = knifeandBoss.GetKnife(count);
        Boss = knifeandBoss.GetBoss(count);
        knifeCount = knifeandBoss.GetKnifeCount(count);
    }

    private void Start()
    {
        gameUi.DisplayInitialKnifeIcons(knifeCount);
        SpawnBoss();
        SpawnKnife();
    }

    public void OnSuccessfullKnifeHit()
    {
        if(knifeCount > 0)
        {
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequence", win);
    }

    private void SpawnBoss()
    {
        GameObject boss = Instantiate(Boss, bossSpawnPosition, Quaternion.identity);
        logMotor = boss.GetComponent<LogMotor>();
    }

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(Knife, knifeSpawnPosition, Quaternion.identity);
    }

    IEnumerator GameOverSequence(bool win)
    {
        if(win)
        {
            yield return new WaitForSecondsRealtime(1);

            Destroy(logMotor.gameObject);
            count = ++count % 4;
            Boss = knifeandBoss.GetBoss(count);
            Knife = knifeandBoss.GetKnife(count);
            knifeCount = knifeandBoss.GetKnifeCount(count);

            gameUi.DisplayInitialKnifeIcons(knifeCount);
            SpawnBoss();
            SpawnKnife();
        }
        else
        {
            gameUi.ShowRestartButton();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public LogMotor GetLogMotor()
    {
        return logMotor;
    }
}
