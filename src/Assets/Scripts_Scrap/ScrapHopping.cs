using UnityEngine;
using System.Collections;


public class ScrapHopping : MonoBehaviour
{
    [SerializeField] Rigidbody2D RigidBody2D;

    [SerializeField] float OnenableDeray = 0.4f;
    [Space]
    [SerializeField] float MinAddPowerY = 13f;
    [SerializeField] float MaxAddPowerY = 15f;
    [SerializeField] float MinAddPowerX = -3f;
    [SerializeField] float MaxAddPowerX = 3f;
    [Space]
    [SerializeField] float MinRotateSpeedZ = -30f;
    [SerializeField] float MaxRotateSpeedZ = 30f;

    static readonly float DestroyDeley = 3f;

    Vector3 StartScale;

    private void Start()
    {
        StartScale = transform.localScale;
        transform.localScale = Vector2.zero;
        StartCoroutine(SetActiveAfterSeconds());
    }

    IEnumerator SetActiveAfterSeconds()
    {
        // �w��b���҂�
        yield return new WaitForSeconds(OnenableDeray);

        transform.localScale = StartScale;

        Vector2 force = new()
        {
            x = Random.Range(MinAddPowerX, MaxAddPowerX),
            y = Random.Range(MinAddPowerY, MaxAddPowerY)
        };

        RigidBody2D.AddForce(force,ForceMode2D.Impulse);

        // �I�u�W�F�N�g�폜
        Destroy(gameObject, DestroyDeley);

        float rotateSpeedZ = Random.Range(MinRotateSpeedZ, MaxRotateSpeedZ);

        StartCoroutine(RotateZLoop(rotateSpeedZ));
    }

    private IEnumerator RotateZLoop(float speed)
    {
        while (true)
        {
            transform.Rotate(0f, 0f, speed * Time.fixedDeltaTime);
            yield return null;
        }
    }
}
