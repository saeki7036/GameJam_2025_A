using Unity.VisualScripting;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    [SerializeField] GameObject Effect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 Force1 = new Vector2(200, 300);
        Vector2 Force2 = new Vector2(200, 0);
        Vector2 Force3 = new Vector2(-200, 300);
        Vector2 Force4 = new Vector2(-200, 0);

        GameObject effect1 = Instantiate(Effect);
        GameObject effect2 = Instantiate(Effect);
        GameObject effect3 = Instantiate(Effect);
        GameObject effect4 = Instantiate(Effect);

        Rigidbody2D rb1 = effect1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = effect2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = effect3.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = effect4.GetComponent<Rigidbody2D>();

        if (rb1 != null && rb2 != null && rb3 != null && rb4 != null)
        {
            rb1.AddForce(Force1);
            rb2.AddForce(Force2);
            rb3.AddForce(Force3);
            rb4.AddForce(Force4);
        }

        Destroy(effect1, 0.6f);
        Destroy(effect2, 0.6f);
        Destroy(effect3, 0.6f);
        Destroy(effect4,0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
