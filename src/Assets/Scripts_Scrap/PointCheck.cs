using UnityEngine;

public class PointCheck : MonoBehaviour
{
    [SerializeField] RightHandMovementScript rightHand;
    [SerializeField] LeftHandMovementScript leftHand;

    [SerializeField] EffectScript effectScript;

    [SerializeField] GameObject SuccessEffect;
    [SerializeField] GameObject[] FailureEffects;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip SuccessClip;
    [SerializeField] AudioClip FailureClip;

    public void PointSameCheck(ScrapObject scrapObject)
    {
        int left = leftHand.GetLpositionPoint;
        int right = rightHand.GetRpositionPoint;

        rightHand.CloseHand();
        leftHand.CloseHand();

        bool isSame = scrapObject.IsSuccess(left, right);

        Vector3 crushedPrehabPos = scrapObject.GetTransform.position;
        Quaternion crushedPrehabQuaternion = scrapObject.GetTransform.rotation;

        if (isSame)
        {
            Debug.Log("Same");

            CrushedPrehabInstantiate(
                scrapObject.GetSuccessPrehab,
                crushedPrehabPos,
                crushedPrehabQuaternion);

            effectScript.EffectInstantiate(SuccessEffect);

            audioSource.PlayOneShot(SuccessClip);
        }
        else
        {
            Debug.Log("NotSame");

            CrushedPrehabInstantiate(
                scrapObject.GetFailurePrehab,
                crushedPrehabPos,
                crushedPrehabQuaternion);

            effectScript.EffectsPopUp(FailureEffects);

            audioSource.PlayOneShot(FailureClip);
        }
    }

    public void CrushedPrehabInstantiate(GameObject prehab, Vector3 pos, Quaternion quaternion)
    {
        var transforms = Instantiate(prehab, pos, quaternion);
    }
}
