using UnityEngine;

public class Playerattack : MonoBehaviour
{
   [SerializeField] private float attackCooldown;
   private Animator anima;
   private NewBehaviourScript NewBehaviourScript;
   private float cooldwontimer = 1000000000;
   private void Awake()
   {
    anima=GetComponent<Animator>();
    NewBehaviourScript = GetComponent<NewBehaviourScript>();
   }
   private void Update()
   {
    if (Input.GetKey(KeyCode.Z))
    Attack();
    cooldwontimer += Time.deltaTime;
   }
   private void Attack()
   {
    anima.SetTrigger("attack");
    cooldwontimer=0;
   }
}
