using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FallingObjects : MonoBehaviour
{
    public static FallingObjects instance;

    [SerializeField]
    private float xLimit;

    [SerializeField]
    private float[] xPositions;

    [SerializeField]
    private Faller[] faller;

    private float currentTime;

    List<float> usedPositions = new List<float>();
    private int fallerIndex;
    float xPos = 0;
    int rand;


    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        usedPositions.AddRange(xPositions);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.instance.StartMoving == true)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                getFalling();
            }
        }
    }

    void FeltObject(float xPos)
    {
        int r = Random.Range(0, 5);
        string fallingObjectName = "";
        if (r == 0) fallingObjectName = "papier";
        else if (r == 1) fallingObjectName = "plast";
        else if (r == 2) fallingObjectName = "sklo";
        else if (r == 3) fallingObjectName = "phone";
        else if (r == 4) fallingObjectName = "computer";



        GameObject faller = PoolOptimalize.instance.GetObjectFromPool(fallingObjectName);
        faller.transform.position = new Vector3(xPos, transform.position.y, 0);
        faller.SetActive(true);
    }

    void getFalling()
    {
        usedPositions = new List<float>();
        usedPositions.AddRange(xPositions);
        fallerIndex = Random.Range(0, faller.Length);
        currentTime = faller[fallerIndex].delayTime;
        if (faller[fallerIndex].fallingCount == 1)
            xPos = Random.Range(-xLimit, xLimit);
        else if(faller[fallerIndex].fallingCount > 1)
        {
            rand = Random.Range(0, usedPositions.Count);
            xPos = usedPositions[rand];
            usedPositions.RemoveAt(rand);
        }

        for (int i = 0; i < faller[fallerIndex].fallingCount; i++)
        {
            FeltObject(xPos);
            rand = Random.Range(0, usedPositions.Count);
            xPos = usedPositions[rand];
            usedPositions.RemoveAt(rand);
        }
    }
}

[System.Serializable]
public class Faller
{
    public float delayTime;
    public float fallingCount;
}
