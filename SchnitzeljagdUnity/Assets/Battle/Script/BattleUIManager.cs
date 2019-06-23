using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleUIManager : MonoBehaviour {

    private float countdown = 3;
    public TextMeshProUGUI battleInfo;

    public Joystick joystick;

    public Button actionButton;
    public TextMeshProUGUI actionButtonText;

    // Start is called before the first frame update
    void Start() {
        Physics.gravity = new Vector3(0, -98.1f, 0);
        StartCoroutine(Countdown());
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
    IEnumerator Countdown() {
        StartCoroutine(CountdownDisplay());

        Time.timeScale = 0;
        float startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < startTime + countdown) {
            Debug.Log(Time.realtimeSinceStartup);
            yield return null;
        }

        Time.timeScale = 1;
    }
    IEnumerator CountdownDisplay() {
        for(float countdownInfo = countdown; countdownInfo > 0 ; countdownInfo--) {
            battleInfo.text = countdownInfo.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        battleInfo.text = string.Empty;
    }
}
