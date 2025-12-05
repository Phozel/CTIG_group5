using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, followTransform.position.y, -10);
    }
}
