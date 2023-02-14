using UnityEngine;

public sealed class Laser : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float laserRange;

    [SerializeField]
    [Range(1, 10)]
    private int bounces = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Ray ray = new Ray(this.transform.position, this.transform.right * laserRange);

        for (int i = 0; i < bounces; ++i)
        {
            Gizmos.DrawRay(ray);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, ray.direction.magnitude))
            {
                Gizmos.DrawWireSphere(raycastHit.point, 0.05f);

                Vector2 reflectedVector = ((Vector2)ray.direction - 2 * Vector2.Dot(ray.direction, raycastHit.normal) * (Vector2)raycastHit.normal).normalized * laserRange;
                Gizmos.DrawRay(raycastHit.point, reflectedVector);

                ray.origin = raycastHit.point;
                ray.direction = reflectedVector;
            }
            else
                break;
        }
    }
}
