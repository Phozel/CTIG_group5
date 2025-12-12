using UnityEngine;
using System.Linq;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;

    void Awake()
    {
        followTransform = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, followTransform.position.y, -10);
    }
}
