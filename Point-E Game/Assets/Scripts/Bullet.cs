using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private EnemyStats enemyStats;
    public float speed;
    public float damage;
    public GameObject impactEffect;

    public GameObject parent;

    public void SetTarget(Transform _target)
    {
        target = _target;
        enemyStats = target.GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        enemyStats.enemyHealth -= damage;
        if(enemyStats.enemyHealth <= 0)
        {
            PlayerStats.money += enemyStats.enemyReward;
            parent.GetComponent<BuildingStats>().buildingXP++;
            GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation, parent.transform);
            Destroy(effectInstance, 2f);
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
