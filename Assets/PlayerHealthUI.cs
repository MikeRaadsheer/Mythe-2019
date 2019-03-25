using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] private float health = 100;
    private Player player;
    private Image healthBar;
    [SerializeField] private Image healthBarBackground;

    [SerializeField] private TextAsset playerJson;
    #endregion

    #region Unity Methods
    private void Awake() {
        //player = JsonUtility.FromJson<Player>(playerJson.ToString());
        healthBar = GetComponent<Image>();
    }

    void Start() {
        healthBar.fillMethod = Image.FillMethod.Horizontal;
        healthBar.fillOrigin = 0; // Fills image from the left
    }

    void Update() {
        health -= 0.1f;

        healthBar.fillAmount = Map(health, 0, 100, 0, 1); // Maps health from 0 and 100 to 0 and 1
        healthBar.color = Color.Lerp(Color.red, Color.green, Map(health, 0, 100, 0, 1));
        healthBarBackground.color = Color.Lerp(Color.red, Color.green, Map(health, 0, 100, 0, 1));

        var color = healthBarBackground.color;
        color.a = 0.3f;
        healthBarBackground.color = color;
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    // Returns the value in the new range
    float Map(float value, float low1, float high1, float low2, float high2) {
        return Mathf.Clamp(low2 + (value - low1) * (high2  - low2) / (high1 - low1), low2, high2);
    }
    #endregion
}
