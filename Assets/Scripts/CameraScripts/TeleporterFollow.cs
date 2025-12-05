using UnityEngine;

public class TeleporterFollow : MonoBehaviour
{
    public Transform followTransform;

    // Update is called once per frame
    void Update()
    {
        if (this.name == "LeftTeleport")
            this.transform.position = new Vector3(-7, followTransform.position.y, -10);
        else if (this.name == "RightTeleport")
            this.transform.position = new Vector3(7, followTransform.position.y, -10);
    }
}
