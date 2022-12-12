using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
            return;
        transform.position = new Vector3(offset + target.position.x,
            transform.position.y,
            transform.position.z);
    }
}
