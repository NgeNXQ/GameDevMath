using UnityEngine;

public sealed class WorldToLocal : MonoBehaviour
{
    [SerializeField]
    private Vector3 world;

    [SerializeField]
    private Vector3 local;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, this.transform.right);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, this.transform.up);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(world, 0.05f);

        Vector3 related = world - this.transform.position;
        local = new Vector3(Vector3.Dot(this.transform.right, related), Vector3.Dot(this.transform.up, related), 0.0f);

        Gizmos.DrawLine(Vector3.zero, this.transform.position + local);
    }
}
