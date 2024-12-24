using UnityEngine;

public class Enemy: MonoBehaviour
{
    public Transform player;

	public float damageSize = 10f;
    public float speed = 3f;
    
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        
        direction.y = 0f;

        transform.position += direction * speed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion RotationToPlayer = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, RotationToPlayer, 360 * Time.deltaTime);
        }
    }

	void OnTriggerStay(Collider collider) {
		if (collider.CompareTag("Player")) {
			Stats playerStats = collider.GetComponent<Stats>();
			playerStats.TakeDamage(damageSize * Time.deltaTime);
		}
	}
}
