using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion1 : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    //--------
    public Rigidbody rb;
    public float Fuerzadesalto = 8f;
    public bool puedoSaltar;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Aseg�rate de tener el componente Rigidbody.
    }

    // FixedUpdate is used for physics updates
    void FixedUpdate()
    {
        // Recoger los inputs
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Aplicar rotaci�n
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

        // Aplicar movimiento
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        // Actualizar par�metros del Animator
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        // L�gica de salto
        if (puedoSaltar && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("salte", true);
            rb.AddForce(new Vector3(0, Fuerzadesalto, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Si puedoSaltar es falso, significa que el personaje est� en el aire
        if (!puedoSaltar)
        {
            EstoyCayendo();
        }
        else
        {
            anim.SetBool("tocosuelo", true);
        }
    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocosuelo", false);
        anim.SetBool("salte", false);
    }
}
