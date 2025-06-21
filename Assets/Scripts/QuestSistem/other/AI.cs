using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
   public static AI Instance;
   private NavMeshAgent agent;
   public GameObject message;
   public Transform stoyka;
   public Transform GoOut;
   public bool goOut;

   void Start()
   {
      Instance = this;
      agent = GetComponent<NavMeshAgent>();
      agent.SetDestination(stoyka.position);
   }

   void Update()
   {
      if (agent.remainingDistance <= agent.stoppingDistance)
      {
         if (message != null)
         {
            message.SetActive(true);
         }
      }

      if (goOut)
      {
         agent.SetDestination(GoOut.position);
      }
   }
}
