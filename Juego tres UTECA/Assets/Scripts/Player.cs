using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool atacando;
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
    private int sky_;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    public void Mover()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !atacando && !saltando && inground)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            ani.SetBool("run", true);
        }
        else
        {
            ani.SetBool("run", false);
        }

        if(Input.GetKey(KeyCode.DownArrow) && !atacando && !saltando && inground)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
            ani.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.RightArrow) && !atacando)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            ani.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !atacando)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 100, 0);
            ani.SetBool("run", true);
        }
    }

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.C) && !saltando && inground)
        {
            Ypos_Piso = transform.position.y;
            saltando = true;
            inground = false;
        }

        if(saltando)
        {
            switch (Fases)
            {
                case 0:

                    Gravedad = AlturaSalto;
                    Fases = 1;

                    break;

                case 1:

                    if (Gravedad > 0 )
                    {
                        Gravedad -= PotenciaSalto * Time.deltaTime;
                    }
                    else
                    {
                        Fases = 2;
                    }

                    break;
            }


        }
    }

    void SetTransformY(float n)
    {
        transform.position = new Vector3(transform.position.x, n, transform.position.z);
    }

    public void Detector_Piso()
    {
        if(!saltando && !atacando)
        {
            sky_ = 0;

            if (Ypos == Ypos_Piso)
            {
                inground = true;
            }
            ani.SetBool("jump", false);
        }

        else
        {
            ani.SetBool("jump", true);
        }

        if (inground)
        {
            Gravedad = 0;
            Fases = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
