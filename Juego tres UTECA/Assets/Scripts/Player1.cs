using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player1 : Fighter
{
    [SerializeField]
    public AudioClip golpeSonido;

    public static ControladorSonidos Instance;

    private AudioSource audioSource;

    Vector2 cntrl;

    public override void init()
    {
        base.init();
    }

    public void Start()
    {
        init();
        
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }

    // Update is called once per frame
    void Update()
    {

        cntrl = new Vector2(Input.GetAxis("Horizontal"), 
            Input.GetAxis("Vertical"));

        if(_lifes <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(cntrl.x != 0)
        {
            sr.flipX = cntrl.x < 0;
        }
            

        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Punch());
            EjecutarSonido(golpeSonido);
        }
            

        isGuard = Input.GetKey(KeyCode.X);

        anim.SetBool("IsGuard", isGuard);
            
        //if(_lifes <= 0)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}



        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Punch")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("GetPunch")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Guard"))
        {
            anim.SetBool("IsWalking", cntrl.magnitude != 0);
            rb.velocity = new Vector2(cntrl.x * horizontalSpeed,
                cntrl.y * verticalSpeed);
            transform.position = new Vector3(transform.position.x,
                Mathf.Clamp(transform.position.y, LimitsY.y, LimitsY.x),
                transform.position.z);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Salir...");
            Application.Quit();
        }
    }
}
