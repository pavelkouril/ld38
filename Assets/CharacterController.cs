using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterController : MonoBehaviour {

    private Vector3 mMove;
    private Animator mAnimator;
    float mTurnAmount;
    float mForwardAmount;

    // Use this for initialization
    void Start ()
    {
        mMove = new Vector3();
        mAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void Move(Vector3 move)
    {
        if (move.magnitude > 1.0f)
        {
            move.Normalize();
        }

        move = transform.InverseTransformDirection(move);

        mTurnAmount = Mathf.Atan2(move.x, move.z);
        mForwardAmount = move.z;

        mAnimator.SetFloat("Forward", mForwardAmount, 0.1f, Time.deltaTime);
        mAnimator.SetFloat("Turn", mTurnAmount, 0.1f, Time.deltaTime);

        /*CheckGroundStatus();
        move = Vector3.ProjectOnPlane(move, m_GroundNormal);
        m_TurnAmount = Mathf.Atan2(move.x, move.z);
        m_ForwardAmount = move.z;

        ApplyExtraTurnRotation();

        // control and velocity handling is different when grounded and airborne:
        if (m_IsGrounded)
        {
            HandleGroundedMovement(crouch, jump);
        }
        else
        {
            HandleAirborneMovement();
        }

        ScaleCapsuleForCrouching(crouch);
        PreventStandingInLowHeadroom();

        // send input and other state parameters to the animator
        UpdateAnimator(move);*/
    }

    private void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        mMove = v * Vector3.forward + h * Vector3.right;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            mMove *= 0.5f;
        }

        // pass all parameters to the character control script
        Move(mMove);
    }
}
