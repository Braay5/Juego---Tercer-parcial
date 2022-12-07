using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class Player1 : MonoBehaviour
{
    static Vector2 LimitsY = new Vector2(1.18f, -3.68f);


    [SerializeField]
    float verticalSpeed;
    [SerializeField]
    float horizontalSpeed;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    Vector2 cntrl;

    // Update is called once per frame
    void Update()
    {
        cntrl = new Vector2(Input.GetAxis("Horizontal"), 
            Input.GetAxis("Vertical"));

        if(cntrl.x != 0)
            sr.flipX = cntrl.x < 0;

        anim.SetBool("IsWalking", cntrl.magnitude != 0);
        rb.velocity = new Vector2(cntrl.x * horizontalSpeed, cntrl.y * verticalSpeed);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LimitsY.y, LimitsY.x), transform.position.z);
    }
}
