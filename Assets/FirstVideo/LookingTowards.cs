using UnityEngine;

public sealed class LookingTowards : MonoBehaviour
{
    [SerializeField]
    private Transform item;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float threshold;

    private void OnDrawGizmos()
    {
        Vector3 playerToItem = (item.position - this.transform.position).normalized;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(this.transform.position, this.transform.position + playerToItem);

        Gizmos.color = Vector3.Dot(this.transform.right, playerToItem) > threshold ? Color.green : Color.white;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.right);  
    }
}
