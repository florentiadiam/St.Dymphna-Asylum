using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 2.5f;
    public float attackCooldown = 1.5f;

    private float lastAttackTime = 0f;
    private Animator animator;
    private Transform player;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time >= lastAttackTime)
        {
            // Έλεγχος: Αν ο παίκτης είναι αόρατος, μην τον χτυπάς
            PlayerPowerUp power = player.GetComponent<PlayerPowerUp>();
            if (power != null && power.isInvisible)
                return;

            // Trigger attack animation
            animator.SetTrigger("AttackTrigger");

            // Damage the player
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            lastAttackTime = Time.time + attackCooldown;
        }
    }
}
