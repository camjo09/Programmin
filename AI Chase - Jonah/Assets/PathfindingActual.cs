using UnityEngine;


public class PathfindingActual : MonoBehaviour
{
    #region Variables
    public float Speed = 5.0f;
    public GameObject[] Waypoint;
    public GameObject AiSprite;
    public float MinDistanceToWaypoint;
    public GameObject playerObject;
    public float ChasePlayerDistance;
    public float DamagePlayerDistance;
    private int CurrentWaypoint = 0;
    public GameObject YouLose;
    public PlayerController playerController;
    float AttackCooldown = 1f;
    public float DealDamage;
    float TimeOfAttack = float.MinValue;
    public float AiHealth = 3;
    #endregion



    void Update()
    #region Victory Lap
    {
        if (playerController.Health <= 0)
        {
            Speed = 1000;

        }
        #endregion
        #region AI Movement
        if (playerController.Health > 0 && AiHealth <= 1)
        {
            MoveAI(playerObject.transform.position, -Speed);
        }
        else if (Vector2.Distance(playerObject.transform.position, AiSprite.transform.position) < DamagePlayerDistance)
        {
            if (Time.time > TimeOfAttack + AttackCooldown)
            {
                playerController.TakeDamage(DealDamage);
                TimeOfAttack = Time.time;
            }
        }
        else if (Vector2.Distance(playerObject.transform.position, AiSprite.transform.position) < ChasePlayerDistance)
        {
            MoveAI(playerObject.transform.position, Speed);
        }
        else
        {
            Patrol();
        }
 
       

    }
#endregion
    private void Patrol()
    #region Patrol
    {
       
        if (CurrentWaypoint >= Waypoint.Length)
        {
            CurrentWaypoint = 0;
        }

        MoveAI(Waypoint[CurrentWaypoint].transform.position,Speed);

        if (Vector2.Distance(transform.position, Waypoint[CurrentWaypoint].transform.position) <= 0.01f)
        {
            CurrentWaypoint++;
        }
       
    }
    #endregion
    private void MoveAI(Vector2 targetPosition, float speed)
    #region MoveAI
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

    }
    #endregion

}