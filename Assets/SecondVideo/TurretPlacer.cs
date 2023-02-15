using UnityEngine;

public class TurretPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject turret;

    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float interactionRange = 5.0f;

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);

        Gizmos.color = Color.white;
        Gizmos.DrawRay(ray.origin, ray.direction * interactionRange);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange))
        {
            Vector3 yOrigin = hit.normal;
            Vector3 zOrigin = Vector3.Cross(this.transform.right, yOrigin).normalized;
            Vector3 xOrign = Vector3.Cross(yOrigin, zOrigin).normalized;

            Gizmos.color = Color.red;
            Gizmos.DrawRay(hit.point, xOrign);

            Gizmos.color = Color.green;
            Gizmos.DrawRay(hit.point, yOrigin);

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hit.point, zOrigin);

            turret.transform.position = hit.point;
            turret.transform.rotation = Quaternion.LookRotation(zOrigin, yOrigin);  
        }
    }
}
