using UnityEngine;
using UnityEngine.UI;

public class ResaltViewer : MonoBehaviour
{
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
    }
}
