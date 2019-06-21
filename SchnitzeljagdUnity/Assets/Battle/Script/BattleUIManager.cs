using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleUIManager : MonoBehaviour {

    public Joystick joystick;

    public Button actionButton;
    public TextMeshProUGUI actionButtonText;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        UpdateActionButtonText();
    }

    private void UpdateActionButtonText() {
        if(!JoystickIsUsed()) {
            actionButtonText.text = "Attack";
        } else {
            actionButtonText.text = "Evade";
        }
    }
    private bool JoystickIsUsed() {
        bool isUsed = false;

        if(joystick.Horizontal != 0 || joystick.Vertical != 0) {
            isUsed = true;
        }
        return isUsed;
    }

}
