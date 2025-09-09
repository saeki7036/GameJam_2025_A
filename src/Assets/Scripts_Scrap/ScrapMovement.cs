using System.Collections.Generic;
using UnityEngine;

public class ScrapMovement : MonoBehaviour
{
    [SerializeField, Min(0.0001f)] float MovementTime = 1.5f;

    [SerializeField] Transform TargetTransform;

    [SerializeField]PointCheck pointCheck;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip DestroyClip;

    List<ScrapObject> ScrapObjects;

    public void AddList(ScrapObject scrapObject) => ScrapObjects.Add(scrapObject);


    void Start()
    {
        ScrapObjects = new List<ScrapObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = ScrapObjects.Count - 1; i >= 0; i--)
        {
            if (ScrapObjects[i] == null) 
            {
                ScrapObjects.RemoveAt(i);
            }

            var scrapTransform = ScrapObjects[i].GetTransform;

            if(TargetTransform.position != scrapTransform.position)
            {
                var travelingTime = ScrapObjects[i].TravelingTime;

                travelingTime += Time.fixedDeltaTime;

                // 0Å`1 ÇÃï‚ä‘åWêî
                float t = Mathf.Clamp01(travelingTime / MovementTime);

                ScrapObjects[i].SetScale(t);

                //à⁄ìÆÇ≥ÇπÇÈ
                scrapTransform.position = Vector3.Lerp(ScrapObjects[i].GetSpawnPosition, TargetTransform.position, t);

                ScrapObjects[i].TravelingTime = travelingTime;
            }

            else if(TargetTransform.position == scrapTransform.position)
            {
                pointCheck.PointSameCheck(ScrapObjects[i]);
                ScrapObjects[i].DestroyScrap();
                ScrapObjects.RemoveAt(i);

                audioSource.PlayOneShot(DestroyClip);
            }
        }
    }
}
