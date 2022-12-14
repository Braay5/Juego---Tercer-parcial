using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TextMesh))]

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float lifeTime;

    TextMesh tm;

    void Start()
    {
        tm = GetComponent<TextMesh>();
        Destroy(gameObject, lifeTime);
    }

    public void Init(string text)
    {
        tm.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
