using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform transformToFollow;  // The Transform that this object will follow

    void Update()
    {
        if (transformToFollow != null)
        {
            // Make this object's position and rotation match the target Transform
            transform.position = transformToFollow.position;
            transform.rotation = transformToFollow.rotation;
        }
    }
}
