using UnityEngine;

public sealed class LocalToWorld : MonoBehaviour
{
    [SerializeField]
    private Vector3 position;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, this.transform.right);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, this.transform.up);

        Vector3 point = this.transform.position + this.transform.right * position.x + this.transform.up * position.y;

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(point, 0.05f);
    }
}
