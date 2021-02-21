using Mirror;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class CharacterAnimator : NetworkBehaviour
{
    /// <summary>
    /// Dead zone to consider movement as stopped
    /// </summary>
    public float movementDeadZone = 0.01f;

    /// <summary>
    /// Dead zone to consider turning action as stopped
    /// </summary>
    public float turningDeadZone = 0.01f;

    /// <summary>
    /// Amount of time falling to switch to falling animation
    /// </summary>
    public float fallingThreshold = 0.1f;

    /// <summary>
    /// Character controller to move character
    /// </summary>
    private CharacterController characterController;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;

    /// <summary>
    /// Animator for controlling character
    /// </summary>
    public Animator animator;

    public void Start()
    {
        this.characterController = this.GetComponent<CharacterController>();
        
    }

    public void Update()
    {

        bool jumping = characterController.velocity.y >= 0.1f;
        bool moving = !jumping && characterController.velocity.magnitude > 0;

        // Set animator fields based on information
        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        // Set moving if movement is greater than dead zone
        animator.SetBool("Moving", moving);
        // Set turning value based on turning direction
        // animator.SetFloat("Rotation", cameraController.frameRotation > 0 ? 1 : -1);
        // animator.SetBool("Turning", !moving && !jumpingOrFalling && Mathf.Abs(cameraController.frameRotation) > this.turningDeadZone);
        // animator.SetBool("Jumping", jumping);
        // animator.SetBool("Falling", falling);
    }
}


