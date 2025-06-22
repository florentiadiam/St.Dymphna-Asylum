using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;

    void Start()
    {
        // initial offset from the player (camera transform-player transform)
        offset=transform.position-playerTransform.position;
    }

    void LateUpdate()
    {
        //rotate the offset based on the rotation of the player
        Vector3 rotatedOffset=playerTransform.rotation*offset;

        //Camera is positioned right behind of the player
        transform.position=playerTransform.position+rotatedOffset;

        //Camera looks at the player (his head)
        transform.LookAt(playerTransform.position+ Vector3.up*13f);
    }
}
