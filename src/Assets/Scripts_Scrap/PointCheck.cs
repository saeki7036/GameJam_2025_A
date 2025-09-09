using UnityEngine;

public class PointCheck : MonoBehaviour
{
    [SerializeField] RightHandMovementScript rightHand;
    [SerializeField] LeftHandMovementScript leftHand;

    int left = 2, right = 2;

    public void PointSameCheck(ScrapObject scrapObject)
    {
        left = leftHand.GetLpositionPoint;
        right = rightHand.GetRpositionPoint;

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
        }
        else
        {
            Debug.Log("NotSame");

            CrushedPrehabInstantiate(
                scrapObject.GetFailurePrehab,
                crushedPrehabPos,
                crushedPrehabQuaternion);
        }
    }

    public void CrushedPrehabInstantiate(GameObject prehab, Vector3 pos, Quaternion quaternion)
    {
        var transforms = Instantiate(prehab, pos, quaternion);
    }
}
