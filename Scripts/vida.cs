using UnityEngine;
using UnityEngine.SceneManagement;
public class vida : MonoBehaviour
{
    [SerializeField] private float iniciovida;
    private bool dead;
    [SerializeField]private Behaviour[] components;
    private bool vivo;
    public float actualvida { get; private set; }


    private void Awake()
    {
        actualvida=iniciovida;
    }
    public void Damage(float _damage)
    {
        actualvida= Mathf.Clamp(actualvida-_damage, 0, iniciovida);
         if (actualvida> 0)
        {
         
        }
        else
            {   
            if (!dead)
            {
                
            foreach( Behaviour components in components)
                components.enabled=false;
            dead=true;

            SceneManager.LoadScene("Level1");
             }
             }
    }
    public void agregarvida(float _value)
    {
        actualvida= Mathf.Clamp(actualvida+_value, 0, iniciovida);
    }
    public void Respawn()
    {
        agregarvida(iniciovida);
       
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
