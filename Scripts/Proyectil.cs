using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private float speed=20;
    private bool hit;
    private float direccion;
    private float lifetime;

    private Animator anima;
    private BoxCollider2D BoxCollider;
    private void Awake()
    
    {
        anima = GetComponent<Animator>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direccion;
        transform.Translate(movementSpeed, 0,0);

        lifetime+= Time.deltaTime;
        if(lifetime>2) gameObject.SetActive(false);


    }
    private void OnTriggerEnter2D(Collider2D colision)
    {   
        hit=true;
        BoxCollider.enabled=false;
        anima.SetTrigger("explode");  

     if (colision.tag == "Enemy")
            colision.GetComponent<vidaenemy>()?.Damage(1); 
    }      
    public void SetDireccion(float _direccion)
    {
        lifetime=0;
        direccion=_direccion;
        gameObject.SetActive(true);
        hit=false;
        BoxCollider.enabled=true;
        
        float localScaleX=transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direccion)
            localScaleX=-localScaleX;

        transform.localScale=new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
