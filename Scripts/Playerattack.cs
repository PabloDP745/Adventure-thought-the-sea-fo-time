using UnityEngine;

public class Playerattack : MonoBehaviour
{
   [SerializeField] private Transform firePoint;
   [SerializeField] private GameObject[] Bala;
   private Animator anima;
   private NewBehaviourScript NewBehaviourScript;
   [SerializeField] private float attackCooldown;
   private float cooldwontimer = 1000000000;
   private void Awake()
   {
    anima=GetComponent<Animator>();
    NewBehaviourScript = GetComponent<NewBehaviourScript>();
   }
   private void Update()
   {
    if (Input.GetKey(KeyCode.Z) && cooldwontimer > attackCooldown)
    Attack();
    cooldwontimer += Time.deltaTime;
   }
   private void Attack()
   {
    anima.SetTrigger("attack");
    cooldwontimer=0;

    Bala[findBala()].transform.position=firePoint.position;
    Bala[findBala()].GetComponent<Proyectil>().SetDireccion(Mathf.Sign(transform.localScale.x));
   }
   private int findBala()
   {
      for(int i =0;i<Bala.Length; i++)
      {
         if(!Bala[i].activeInHierarchy)
         return i;
      }
      return 0;
   }
}
