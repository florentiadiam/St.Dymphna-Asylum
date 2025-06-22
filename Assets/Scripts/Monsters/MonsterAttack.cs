using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public int damage= 10;                 // Damage dealt to the player per attack
    public float attackRange= 2.5f;        // Maximum distance to trigger an attack
    public float attackCooldown= 1.5f;     // Delay between consecutive attacks

    private float lastAttackTime= 0f;      // Tracks time for next allowed attack
    private Animator animator;              
    private Transform player;              

    void Start()
    {
        // Get animator and find the player in the scene
        animator= GetComponent<Animator>();
        player= GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // If player reference is missing, do nothing
        if (player==null) return;

        float distance=Vector3.Distance(transform.position, player.position);

        // Check if player is within range and cooldown has passed
        if (distance<=attackRange && Time.time>=lastAttackTime)
        {
            // If player is invisible due to power-up, skip the attack
            PlayerPowerUp power=player.GetComponent<PlayerPowerUp>();
            if (power!= null && power.isInvisible)
                return;

            // Play attack animation
            animator.SetTrigger("AttackTrigger");

            //Apply damage to the player
            PlayerHealth playerHealth=player.GetComponent<PlayerHealth>();
            if (playerHealth!= null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Reset attack cooldown timer
            lastAttackTime=Time.time+attackCooldown;
        }
    }
}
