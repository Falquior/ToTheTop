using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    [Header("Movement")]
    [SerializeField] float movementAceleration;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float groundLinearDrag;

    private float horizontalDirection;
    private bool changingDirection => (playerRigid.velocity.x > 0f && horizontalDirection < 0f) || (playerRigid.velocity.x < 0f && horizontalDirection > 0f);

    [Header("Jump")]
    [SerializeField] float jumpForce = 12f;
    [SerializeField] float airLinearDrag = 2.5f;
    [SerializeField] float fallMultiplier = 8f;
    [SerializeField] float lowJumpFallMultiplier = 8f;

    [Header("Gorund Detection")]
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float groundRaycastLenght;
    private bool onGround;

    [Header("Coyote Time")]
    [SerializeField] float coyoteTime = 0.2f;
    [SerializeField] float coyoteTimeCounter;

    [Header("Jump Buffering")]
    [SerializeField] float jumpBufferTime = 0.2f;
    [SerializeField] float jumpBufferTimeCounter;

    [Header("Components")]
    private Rigidbody2D playerRigid;

    private void Start(){
        playerRigid = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        horizontalDirection = GetInput().x;

        if (onGround)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            jumpBufferTimeCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferTimeCounter -= Time.deltaTime;
        }

        if (jumpBufferTimeCounter > 0f && coyoteTimeCounter > 0f)
        {
            Jump();
            jumpBufferTimeCounter = 0f;
        }

        if(Input.GetButtonUp("Jump")|| Input.GetKeyDown(KeyCode.W))
        {
            coyoteTimeCounter = 0f;
        }
    }

    private void FixedUpdate(){
        CheckCollisions();
        MoveCharacter();

        if (onGround){
            ApplyGroundLinealDrag();
        }else{
            ApplyAirLinearDrag();
            FallMultiplier();
        }
    }

    private Vector2 GetInput(){
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MoveCharacter(){
        playerRigid.AddForce(new Vector2(horizontalDirection, 0) * movementAceleration);

        if (Mathf.Abs(playerRigid.velocity.x) > maxMoveSpeed)
            playerRigid.velocity = new Vector2(Mathf.Sign(playerRigid.velocity.x) * maxMoveSpeed, playerRigid.velocity.y);
    }

    private void ApplyGroundLinealDrag(){
        if(Mathf.Abs(horizontalDirection) < 0.4f || changingDirection){
            playerRigid.drag = groundLinearDrag;
        }else{
            playerRigid.drag = 0f;
        }
    }

    private void ApplyAirLinearDrag(){
        playerRigid.drag = airLinearDrag;
    }

    private void Jump(){
        playerRigid.velocity = new Vector2(playerRigid.velocity.x, 0f);
        playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FallMultiplier(){
        if(playerRigid.velocity.y < 0)
        {
            playerRigid.gravityScale = fallMultiplier;
        }
        else if(playerRigid.velocity.y > 0f && !Input.GetButton("Jump"))
        {
            playerRigid.gravityScale = lowJumpFallMultiplier;
        }
        else
        {
            playerRigid.gravityScale = 1f;
        }
    }

    private void CheckCollisions(){
        onGround = Physics2D.Raycast(transform.position * groundRaycastLenght, Vector2.down, groundRaycastLenght, groundLayer);
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastLenght);
    }
}