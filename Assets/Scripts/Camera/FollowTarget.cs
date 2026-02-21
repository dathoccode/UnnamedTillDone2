using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        // Follow the target's position while maintaining the camera's z-axis position
        this.transform.position = new Vector3(target.position.x, target.position.y, this.transform.position.z);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
