using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordSpawner : MonoBehaviour
{
    public Hord[] hordList;
    public Collider[] spawnAreas;

    private HudManager hudManager;
    private int hordCounter = 0;
    private int enemyHordCounter = 0;
    private int enemyHordMax;

    private void Start()
    {
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

            Instantiate(enemy, transform.position, enemy.transform.rotation);
            enemyHordCounter++;

            hordList[hordCounter].hordInfo[enemyIndex].SpawnCurrent(); // This will reduce enemy count by 1

            Invoke("SpawnCurrentHord", hordList[hordCounter].spawnInterval);
        }
    }
}
