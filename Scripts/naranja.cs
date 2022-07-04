using UnityEngine;

public class naranja : MonoBehaviour
{
    [SerializeField] private float valorvida;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<vida>().agregarvida(valorvida);
            gameObject.SetActive(false);
        }
    }
    
}