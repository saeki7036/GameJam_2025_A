using UnityEngine;

public class BackImageChenger : MonoBehaviour
{
    [SerializeField] CountDownScript countDownScript;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CountImage[] countImages;

    [System.Serializable]
    public struct CountImage
    {
        public Sprite sprite;
        public float count;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countDownScript == null)
            return;

        float Count = countDownScript.GetlimitTime;

        Debug.Log(Count);

        foreach (var image in countImages)
        {
            if (Count > image.count)
            {
                spriteRenderer.sprite = image.sprite;
                break;
            }
        }
        
    }
}
