using UnityEngine;

[CreateAssetMenu(fileName = "ScrapSpwanInfo", menuName = "Scriptable Objects/ScrapSpwanInfo")]
public class ScrapSpwanInfo : ScriptableObject
{
    [SerializeField] GameObject Prehab;
    [SerializeField] float SpwanTime;

    public GameObject GetPrehab => Prehab;

    public float GetSpwanTime => SpwanTime;
}
