using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

public class TurretTriggerView : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float height;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float radius;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float threshold;

    [SerializeField]
    public Transform player;

    private void OnDrawGizmos()
    {
        Gizmos.matrix = Handles.matrix = this.transform.localToWorldMatrix;

        Gizmos.color = Handles.color = IsInTrigger(player) ? Color.red : Color.white;

        float frontSide = Mathf.Sqrt(1 - threshold * threshold);

        Vector3 up = new Vector3(0.0f, height, 0.0f);
        Vector3 right = new Vector3(frontSide, 0.0f, threshold) * radius;
        Vector3 left = new Vector3(-frontSide, 0.0f, threshold) * radius;

        Gizmos.DrawRay(Vector3.zero, up);

        float angle = Vector3.Angle(left, right);

        Gizmos.DrawRay(Vector3.zero, right);
        Gizmos.DrawRay(Vector3.zero, left);
        Handles.DrawWireArc(Vector3.zero, Vector3.up, left, angle, radius);

        Vector3 upRight = up + right;
        Vector3 upLeft = up + left;

        Gizmos.DrawRay(up, right);
        Gizmos.DrawRay(up, left);
        Handles.DrawWireArc(up, Vector3.up, left, angle, radius);

        Gizmos.DrawLine(left, upLeft);
        Gizmos.DrawLine(right, upRight);
    }

    public bool IsInTrigger(Transform player)
    {
        Vector3 triggerPlayer = player.position - this.transform.position;
        Vector3 localTriggerToPlayer = this.transform.InverseTransformVector(triggerPlayer);

        if (localTriggerToPlayer.y < 0.0f || localTriggerToPlayer.y > height)
            return false;

        Vector3 localTriggerToPlayerDirection = localTriggerToPlayer;
        localTriggerToPlayerDirection.y = 0;
        float localTriggerToPlayerMagnitude = localTriggerToPlayerDirection.magnitude;
        localTriggerToPlayerDirection /= localTriggerToPlayerMagnitude;

        if (localTriggerToPlayerDirection.z < threshold)
            return false;

        if (localTriggerToPlayerMagnitude > radius)
            return false;

        return true;
    }
}
#endif