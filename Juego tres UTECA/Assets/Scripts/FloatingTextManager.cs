using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TextMesh))]

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField]
    float speed;

    TextMesh tm;

    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    void Init(string text)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
