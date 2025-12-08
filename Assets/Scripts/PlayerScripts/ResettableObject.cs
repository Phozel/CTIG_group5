using UnityEngine;

public class ResettableObject : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;

    void Awake()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void ResetTransform()
    {
        transform.position = startPos;
        transform.rotation = startRot;
    }
}