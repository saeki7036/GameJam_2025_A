using System.Collections.Generic;
using UnityEngine;

public class ScrapSpwan : MonoBehaviour
{
    [SerializeField] List<Transform> SpawnPositions;

    [SerializeField] List<ScrapSpwanInfo> SpwanList;

    [SerializeField] ScrapMovement scrapMovement;

    int CurrentIndex;
    float CurrentTimeCount;

    void Start()
    {
        CurrentIndex = 0;
        CurrentTimeCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SpwanList == null || SpwanList.Count <= 0)
        {
            Debug.Log("SpwanList‚ª³‚µ‚­‚È‚¢");
            return;
        }

        if (SpwanList.Count <= CurrentIndex)
        {
            Debug.Log("SpawnI—¹‚µ‚½");
            return;
        }

        CurrentTimeCount += Time.fixedDeltaTime;

        if (SpwanList[CurrentIndex].GetSpwanTime <= CurrentTimeCount)
        {
            SpwanScrap(SpwanList[CurrentIndex].GetPrehab);
            CurrentIndex++;
        }
    }

    void SpwanScrap(GameObject prehab)
    {
        GameObject scrap = Instantiate(
            prehab, 
            SpawnPositions[Random.Range(0, SpawnPositions.Count)].position,
            prehab.transform.rotation);

        scrapMovement.AddList(scrap.GetComponent<ScrapObject>());
    }
}


