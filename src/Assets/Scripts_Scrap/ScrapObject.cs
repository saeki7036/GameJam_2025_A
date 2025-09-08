using UnityEngine;
using System.Collections;

public class ScrapObject : MonoBehaviour
{
    [SerializeField] GameObject SuccessPrehab;
    [SerializeField] GameObject FailurePrehab;

    [SerializeField] float MaxScale = 0.4f;
    [SerializeField] float MinScale = 0.2f;

    [SerializeField] SuccessPoint[] successPoints;

    static readonly float DestroyDeley = 0.2f;

    float travelingTime;

    public float TravelingTime
    {
        set
        { travelingTime = value; }
        get
        { return travelingTime; }
    }

    Transform ScrapTransform;

    Vector3 SpawnPosition;

    private void OnEnable()
    {
        travelingTime = 0f;
        ScrapTransform = transform;
        SpawnPosition = transform.position;
    }

    public GameObject GetSuccessPrehab => SuccessPrehab;
    public GameObject GetFailurePrehab => FailurePrehab;


    public Transform GetTransform => ScrapTransform;

    public Vector3 GetSpawnPosition => SpawnPosition;

    public bool IsSuccess(int leftpoint, int rightpoint)
    {
        foreach (var point in successPoints)
        {
            if(point.IsSuccessPoint(leftpoint , rightpoint))
                return true;
        }

        return false;
    }

    public void SetScale(float percentage)
    {
        float scale = MinScale + (MaxScale - MinScale) * (1f - percentage);

        transform.localScale = Vector3.one * scale;
    }


    public void DestroyScrap() => StartCoroutine(DestroyAfterSeconds(DestroyDeley));

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        // 指定秒数待つ
        yield return new WaitForSeconds(seconds);

        // オブジェクト削除
        Destroy(gameObject);
    }
}

[System.Serializable]
public class SuccessPoint
{
    [SerializeField] int SuccessLeftPoint;
    [SerializeField] int SuccessRightPoint;

    public bool IsSuccessPoint(int leftpoint,int rightpoint)
    {
        return SuccessLeftPoint == leftpoint && SuccessRightPoint == rightpoint;
    }
}
