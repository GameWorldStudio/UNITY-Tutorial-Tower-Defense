
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target; 

    private int waypointIndex = 0;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.03f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWayPoint()
    {
        if (waypointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = WayPoints.points[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats._lives--;
        Destroy(gameObject);
    }

}
