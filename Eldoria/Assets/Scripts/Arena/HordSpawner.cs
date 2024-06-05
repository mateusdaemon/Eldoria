using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordSpawner : MonoBehaviour
{
    public Hord[] hordList;
    public Collider[] spawnAreas;
    public PlantSpawner plants;

    private HudManager hudManager;
    private GameManager gameManager;
    private int hordCounter = 0;
    private int enemyHordCounter = 0;
    private int enemyHordMax;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        hudManager = FindObjectOfType<HudManager>();
        hudManager.SetQuestText("Round " + (hordCounter + 1) + "/" + hordList.Length);
        hudManager.EnableNextRound();

        for (int i = 0; i < hordList[0].hordInfo.Length; i++)
        {
            enemyHordMax += hordList[0].hordInfo[i].quantity;
        }

        Invoke("SpawnCurrentHord", hordList[hordCounter].spawnInterval);
    }

    private void Update()
    {
        if (enemyHordMax - enemyHordCounter <= 0 && FindObjectOfType<Enemy>() == null)
        {
            hudManager.RoundComplete();
            hordCounter++;
            enemyHordCounter = 0;
            enemyHordMax = 0;

            if (hordCounter == hordList.Length)
            {
                gameManager.LoadScene("ThankYou");
            } else if (hordCounter == 2 || hordCounter == 4)
            {
                Invoke("SpawnPlant", 3.5f);
            }

            for (int i = 0; i < hordList[hordCounter].hordInfo.Length; i++)
            {
                enemyHordMax += hordList[hordCounter].hordInfo[i].quantity;
            }

            hudManager.SetQuestText("Round " + (hordCounter + 1) + "/" + hordList.Length);
            CancelInvoke("SpawnCurrentHord");
            Invoke("SpawnNextHord", 3);
        }
        
    }

    private void SpawnNextHord()
    {
        Invoke("SpawnCurrentHord", hordList[hordCounter].spawnInterval);
    }

    private void SpawnCurrentHord()
    {
        List<int> availableIndex = new List<int>();
        int curr = 0;

        // Checking which enemies can still be spawned
        foreach (HordSpecific hordInfo in hordList[hordCounter].hordInfo)
        {
            if (hordInfo.quantity > 0)
            {
                availableIndex.Add(curr);
            }

            curr++;
        }

        if (availableIndex.Count > 0)
        {
            // Chossing random enemies between the available ones
            int enemyIndex = availableIndex[(int)Random.Range(0, availableIndex.Count)];
            GameObject enemy = hordList[hordCounter].hordInfo[enemyIndex].hordEnemy;

            // Picking a spawn area
            int areaIndex = (int)Random.Range(0, spawnAreas.Length);
            float areaW = spawnAreas[areaIndex].bounds.size.x/2;
            float areaH = spawnAreas[areaIndex].bounds.size.z/2;
            float xPos = spawnAreas[areaIndex].transform.position.x + Random.Range(-areaW, areaW);
            float zPos = spawnAreas[areaIndex].transform.position.z + Random.Range(-areaH, areaH);
            Vector3 spawnPos = new Vector3(xPos, 2, zPos);

            Instantiate(enemy, spawnPos, enemy.transform.rotation);
            enemyHordCounter++;

            hordList[hordCounter].hordInfo[enemyIndex].SpawnCurrent(); // This will reduce enemy count by 1

            Invoke("SpawnCurrentHord", hordList[hordCounter].spawnInterval);
        }
    }

    public int HordIndex()
    {
        return hordCounter;
    }

    private void SpawnPlant()
    {
        if (hordCounter == 2)
        {
            plants.SpawnGroup(1);
        } else
        {
            plants.SpawnGroup(2);
        }
    }
}
