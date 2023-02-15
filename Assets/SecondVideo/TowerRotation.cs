using UnityEngine;

public sealed class TowerRotation : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float threshold;

    private const string TOWER = "Tower";

    private Transform tower;
    private TurretTriggerView turretTrigger;
    private Quaternion rotationDestination;

    private void Awake()
    {
        turretTrigger = GetComponent<TurretTriggerView>();
        tower = transform.Find(TOWER);
        rotationDestination = Quaternion.identity;
    }

    private void Update()
    {
        if (turretTrigger.IsInTrigger(turretTrigger.player))
        {
            Vector3 towerToPlayer = tower.transform.position - turretTrigger.player.transform.position;
            rotationDestination = Quaternion.LookRotation(towerToPlayer, this.transform.up);
        }

        tower.rotation = Quaternion.Slerp(tower.rotation, rotationDestination, threshold * Time.deltaTime);
    }
}
