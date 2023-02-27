using UnityEngine;

public class PuertaConLlave : MonoBehaviour
{
    public GameObject llave;
    private bool llaveObtenida = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == llave)
        {
            llaveObtenida = true;
            llave.SetActive(false);
        }
        if (llaveObtenida)
        {
            gameObject.SetActive(false);
        }
    }

    public void ObtenerLlave()
    {
        llaveObtenida = true;
        llave.SetActive(false);
    }
}