using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour {

    [SerializeField] private string sceneName;

    // Temporary Code PLS REMOVE SOON
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy") {
            SceneManager.LoadScene(sceneName);
        }
    }

}
