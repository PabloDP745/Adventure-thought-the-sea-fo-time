using UnityEngine;

public class camara : MonoBehaviour
{
    [SerializeField] private Transform Player;
    
    private void Update()
    {
        transform.position = new Vector3(Player.position.x, transform.position.y , transform.position.z);
    }

}
