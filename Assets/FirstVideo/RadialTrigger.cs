using UnityEngine;

public sealed class RadialTrigger : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 50.0f)]
    private float radius;

    [SerializeField]
    private Transform player;

    private void OnDrawGizmos()
    {
        if (player == null)
            return;

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);

        Vector3 playerToTrigger = this.transform.position - player.position;
        float sqrDistance = playerToTrigger.x * playerToTrigger.x + playerToTrigger.y * playerToTrigger.y + playerToTrigger.z * playerToTrigger.z;

        if (sqrDistance < radius * radius)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, radius);
        }
    }
}
