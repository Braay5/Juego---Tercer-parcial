using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool atacando;
    public bool patada;
    public Animator ani;

    private float Gravedad;
    private float Ypos;
    private float Ypos_Piso;
    public bool inground;
    public bool saltando;
    public int Fases;
    public float AlturaSalto;
    public float PotenciaSalto;
    public float Fallen;

    public SpriteRenderer spr;
    private float delay;
    private int sky;

    public void Start()
    {
        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    public void Mover()
    {
        if(Input.GetKey(KeyCode.UpArrow) && !atacando && !saltando && inground)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            ani.SetBool("run", true);
        }
        else
        {
            ani.SetBool("run", false);
        }
        
        if (Input.GetKey(KeyCode.DownArrow) && !atacando && !saltando && inground)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
            ani.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.RightArrow) && !atacando)
        {
            transform.Translate(Vector3.right * -speed * Time.deltaTime);
            ani.SetBool("run", true);
        }
    }
}
