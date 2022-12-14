using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    [SerializeField]
    private AudioClip colector1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ControladorSonidos.Instance.EjecutarSonido(colector1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
