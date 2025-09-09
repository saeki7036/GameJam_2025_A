using UnityEngine;
using UnityEngine.UI;

public class ResaltViewer : MonoBehaviour
{
    [SerializeField] Image RankImage;
    [Space]
    [SerializeField] Sprite[] RankSprites;
    [SerializeField] float[] RankScale;
    [Space]
    [SerializeField] Text ClashedText;
    [SerializeField] Text MissText;

    int MissCount;
    int ClashedCount;

    public void AddCount(bool success)
    {
        if (success)
            ClashedCount++;
        else
            MissCount++;
    }


    void Start()
    {    
        MissCount = 0;
        ClashedCount = 0;
    }

    public void TextView()
    {
        ClashedText.text = "... " + ClashedCount.ToString();
        MissText.text = "... " + MissCount.ToString();

        int Allcount = ClashedCount + MissCount;

        float t = (float)Mathf.Clamp01((float)ClashedCount / (float)Allcount);

        Debug.Log(t);

        for(int i = 0; RankSprites.Length > i; i++)
        {
            RankImage.sprite = RankSprites[i];

            if (RankScale[i] <= t)
                break;
        }
    }
}
