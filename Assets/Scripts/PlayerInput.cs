using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAttack), typeof(PlayerSeatAndGoThroughPlatform))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private PlayerSeatAndGoThroughPlatform playerSeat;
    private bool canMove = true;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerSeat = GetComponent<PlayerSeatAndGoThroughPlatform>();
    }

    private void Update()
    {
        if (canMove)
        {
            float horizontalDirection = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
            bool isJumpButtonDown = Input.GetButtonDown(GlobalStringVars.Jump);
            bool isAttackButtonDown = Input.GetButtonDown(GlobalStringVars.Attack);

            float verticalDirection = Input.GetAxisRaw(GlobalStringVars.VERTICAL_AXIS);
            bool isSeatButtonDown = false;

            if (verticalDirection < 0)
                isSeatButtonDown = true;

            playerMovement.Move(horizontalDirection, isJumpButtonDown, isSeatButtonDown);

            if (isAttackButtonDown)
                playerAttack.Attack();
        }
        else
            playerMovement.Move(0,false,false);

    }

    public void stopMove()
    {
        canMove = false;
    }

    public void startMove()
    {
        canMove = true;
    }

}
