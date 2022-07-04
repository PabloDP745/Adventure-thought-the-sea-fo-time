using UnityEngine;
using UnityEngine.SceneManagement;
public class vidaenemy : MonoBehaviour
{
    [SerializeField] private float iniciovida;
    private bool dead;
    [SerializeField]private Behaviour[] components;
    private bool vivo;
    public float actualvida { get; private set; }
    private Animator anima;

    private void Awake()
    {
        anima = GetComponent<Animator>();
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
            anima.SetTrigger("die");
            foreach( Behaviour components in components)
                components.enabled=false;
            
            dead=true;

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
