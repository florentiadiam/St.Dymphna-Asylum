using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class GhostGirlAI : MonoBehaviour
{
    public Transform player;                    // Reference to the player
    public float detectionDistance = 6f;        // Distance to start chasing
    public float attackDistance = 2f;           // Distance to trigger attack

    public Animator animator;                   // Animator with Idle, Walk, Attack
    public AudioSource screamSound;             // Optional scream audio
    public ParticleSystem ghostEffect;          // Optional ghost effect

    private NavMeshAgent agent;
    private bool isActive = false;
    private bool hasAttacked = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Auto-assign player if not set in Inspector
        if (player == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null) player = p.transform;
        }

        // Ensure ghost starts idle
        animator.SetBool("isWalking", false);
    }

    void Update()
    {
        if (player == null || hasAttacked) return;

        // Ignore height for distance check (XZ only)
        Vector3 ghostXZ = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 playerXZ = new Vector3(player.position.x, 0, player.position.z);
        float distance = Vector3.Distance(ghostXZ, playerXZ);

        // Start chasing if player is within detection range
        if (!isActive && distance <= detectionDistance)
        {
            isActive = true;
            animator.SetBool("isWalking", true);

            if (ghostEffect) ghostEffect.Play();
            if (screamSound) screamSound.Play();
        }

        if (isActive)
        {
            if (distance > attackDistance)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                agent.ResetPath();
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");
                hasAttacked = true;

                // Optional: disable after attack
                StartCoroutine(FadeAndDisappear());
            }
        }
    }

    IEnumerator FadeAndDisappear()
    {
        yield return new WaitForSeconds(2f); // wait for attack to finish

        float fadeTime = 2f;
        float t = 0f;

        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeTime);

            foreach (Renderer r in renderers)
            {
                foreach (Material m in r.materials)
                {
                    if (m.HasProperty("_Color"))
                    {
                        Color c = m.color;
                        c.a = alpha;
                        m.color = c;
                    }
                }
            }

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
