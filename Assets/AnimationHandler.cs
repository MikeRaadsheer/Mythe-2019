using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    void Start() {

    }

    void Update() {
        if(GetComponent<Rigidbody>().velocity.x != 0) {
            GetComponent<Animator>().SetInteger("AnimState", 1);
        } else {
            GetComponent<Animator>().SetInteger("AnimState", 0);
        }

        if(GetComponent<Rigidbody>().velocity.x > 0) {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if(GetComponent<Rigidbody>().velocity.x < 0) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
