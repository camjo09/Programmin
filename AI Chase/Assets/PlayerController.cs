using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    #region Variables
    public float Health = 0;

    public float Speed;
    public PathfindingActual playerController;
    private Rigidbody2D _PlayerRigidBody;

    private float _MoveHorizontal;
    private float _MoveVertical;

    #endregion
    void Start()
    #region Rigidbody
    {
        _PlayerRigidBody = GetComponent<Rigidbody2D>();
    }
    #endregion
   
    public void TakeDamage(float damage)
    #region Cheeky Damage 
    {
        Health -= damage;
    }
    #endregion

    private void Update()
    {
        if((Vector2.Distance(playerController.playerObject.transform.position, playerController.AiSprite.transform.position) < playerController.ChasePlayerDistance) && Input.GetKeyDown(KeyCode.K))
        {
            
            playerController.AiHealth -= 1;


        }
        else
        {

        }
    }
    void FixedUpdate()
     #region Moving Around 
    {
        if (Health > 0)
        {
            _MoveHorizontal = Input.GetAxis("Horizontal");
            _MoveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(_MoveHorizontal, _MoveVertical);

            _PlayerRigidBody.AddForce(movement * Speed);
        }
        else
        {
        
        }
        #endregion


    }
}
