using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;

    void Start()
    {
        // Αρχικό offset από τον παίκτη (θέση κάμερας - θέση παίκτη)
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        // Περιστρέφουμε το offset σύμφωνα με την περιστροφή του παίκτη
        Vector3 rotatedOffset = playerTransform.rotation * offset;

        // Η κάμερα τοποθετείται σε σχετική θέση πίσω από τον παίκτη
        transform.position = playerTransform.position + rotatedOffset;

        // Η κάμερα κοιτάει προς τον παίκτη (π.χ. στο κεφάλι)
transform.LookAt(playerTransform.position + Vector3.up * 13f);
    }
}
