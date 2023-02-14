using UnityEngine;

public sealed class Backstabbing : MonoBehaviour
{
    [SerializeField]
    private Transform enemy;

    [SerializeField]
    [Range(-1.0f, 0.0f)]
    private float threshold;

    private void OnDrawGizmos()
    {
        Vector3 playerToEnemy = (enemy.transform.position - this.transform.position).normalized;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(this.transform.position, this.transform.position + playerToEnemy);

        Gizmos.color = Vector3.Dot(this.transform.right, playerToEnemy) < threshold ? Color.red: Color.white;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.right);
    }
}
