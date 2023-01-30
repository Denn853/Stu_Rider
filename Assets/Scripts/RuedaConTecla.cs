using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuedaConTecla : MonoBehaviour
{
    public KeyCode RuedaPositivo = KeyCode.A;
    public KeyCode RuedaNegativo = KeyCode.B;
    public float torqueForce = 3f; //Escogemos la fuerza que queremos
    Rigidbody2D rb2D; //variable

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //Obtiene componente < Escoge componente
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(RuedaPositivo))
        {
            rb2D.AddTorque(-torqueForce);
        }
        else if (Input.GetKey(RuedaNegativo))
        {
            rb2D.AddTorque(torqueForce);
        }
    }
}
