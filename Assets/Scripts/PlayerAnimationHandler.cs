using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {
    #region Public Fields
    public enum AnimationState {
        Idle,
        Run,
        Punch
    }
    #endregion

    #region Private Fields
    private Rigidbody rigidBody;
    private Animator animator;
    #endregion

    #region Unity Methods
    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Start() {

    }

    void Update() {
        // Set the animation to the correct state based on the movement of the player;
        if(rigidBody.velocity.x < -0.1 || rigidBody.velocity.x > 0.1) {
            ChangeAnimationState(AnimationState.Run);
        } else {
            ChangeAnimationState(AnimationState.Idle);
        }

        if(rigidBody.velocity.z < -0.1 || rigidBody.velocity.z > 0.1) {
            ChangeAnimationState(AnimationState.Run);
        }

        // Get reference to the scale
        var scale = transform.localScale;

        // Invert the scale if the velocity is to the left
        if(rigidBody.velocity.x > 0) {
            scale.x = Mathf.Abs(transform.localScale.x);
        } else if(rigidBody.velocity.x < 0) {
            scale.x = -Mathf.Abs(transform.localScale.x);
        }

        // Apply the new scale to the player
        transform.localScale = scale;
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void ChangeAnimationState(AnimationState state) {
        animator.SetInteger("AnimState", (int)state);
    }
    #endregion
}
