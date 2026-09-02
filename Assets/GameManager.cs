using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject[] roads;
    public Transform stage;

    public GameObject roadClear;
    public GameObject triggerClear;

    public FadeInSprite[] jellyfishFades;

    public SpriteRenderer exitSign;
    public Sprite[] exitSprites;

    public int exitNumber = 0;
    public bool currentIsAnomaly = false;
    public bool currentIsJellyfish = false;

    public Vector3 forwardStagePosition;
    public Vector3 backStagePosition;

    void Start()
    {
        //forwardStagePosition = stage.position;
        exitSign.sprite = exitSprites[exitNumber];
        ShowNormal();
    }

    public void ShowNormal()
    {
        roadClear.SetActive(false);
        triggerClear.SetActive(false);

       for(int i = 0; i < roads.Length; i++)
        {
            roads[i].SetActive(false);
        }
       roads[0].SetActive(true);
       currentIsAnomaly = false;
    }

    public void RandomRoad()
    {
        roadClear.SetActive(false);
        triggerClear.SetActive(false);

        for (int i = 0; i < roads.Length; i++)
        {
            roads[i].SetActive(false);
        }

        int random = Random.Range(0, 2);

        if (random == 0)
        {
            roads[0].SetActive(true);
            currentIsAnomaly = false;
        }
        else
        {
            int anomalyRandom = Random.Range(1, roads.Length);
            roads[anomalyRandom].SetActive(true);
            currentIsAnomaly = true;

            currentIsJellyfish = (anomalyRandom == 2);
        }
    }


    public void CorrectAnswer(bool isBack)
    {
        Debug.Log("CorrecAnswer : isBack = " +  isBack);

        if(exitNumber == 8 && !isBack)
        {
            exitNumber = 9;
            exitSign.sprite = exitSprites[exitNumber];

            for (int i = 0; i < roads.Length; i++)
            {
                roads[i].SetActive(false);
            }

            roadClear.SetActive(true);
            triggerClear.SetActive(true);

            stage.position = forwardStagePosition;

            return;
        }

        exitNumber++;

        if (exitNumber >= 8)
        {
            exitNumber = 8;
        }

        exitSign.sprite = exitSprites[exitNumber];

        if (isBack)
        {
            stage.position = backStagePosition;
        }
        else
        {
            stage.position = forwardStagePosition;
        }

        if (currentIsJellyfish)
        {
            StartCoroutine(WaitForJellyfishFade());
        }
        else
        {
            RandomRoad();
        }
    }

    public void NextArea()
    {
        Debug.Log("NextArea");
        if (!currentIsAnomaly)
        {
            CorrectAnswer(false);//異変なしで前進したので正解
        }
        else
        {
            ResetGame(false);//異変なしで後退したので不正解
        }
    }

    public void BackArea()
    {
        Debug.Log("BackArea currentIsAnomaly = " + currentIsAnomaly);
        if (currentIsAnomaly)
        {
            CorrectAnswer(true);// 異変ありで後退したので正解
        }
        else
        {
            ResetGame(true);//異変ありで前進したので不正解
        }
    }

    public void ResetGame(bool isBack)
    {
        Debug.Log("ResetGameが呼ばれた");

        if (currentIsJellyfish)
        {
            StartCoroutine(WaitForJellyfishFadeReset(isBack));
            return;
        }

        exitNumber = 0;
        exitSign.sprite = exitSprites[exitNumber];

        if (isBack)
        {
            stage.position = backStagePosition;
        }
        else
        {
            stage.position = forwardStagePosition;
        }

        ShowNormal();
    }

    public void FadeOutJellyfish()
    {
        for (int i = 0; i < jellyfishFades.Length; i++)
        {
            jellyfishFades[i].FadeOut();
        }
    }

    IEnumerator WaitForJellyfishFade()
    {
        FadeOutJellyfish();

        yield return new WaitForSeconds(0.7f);

        RandomRoad();
    }

    IEnumerator WaitForJellyfishFadeReset(bool isBack)
    {
        FadeOutJellyfish();

        yield return new WaitForSeconds(0.7f);

        exitNumber = 0;
        exitSign.sprite = exitSprites[exitNumber];

        if (isBack)
        {
            stage.position = backStagePosition;
        }
        else
        {
            stage.position = forwardStagePosition;
        }

        ShowNormal();
    }

}