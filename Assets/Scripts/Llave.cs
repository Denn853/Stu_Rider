using UnityEngine;

public class Llave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PuertaConLlave puerta = FindObjectOfType<PuertaConLlave>();
            puerta.ObtenerLlave();
        }
    }
}