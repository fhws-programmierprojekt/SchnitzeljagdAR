using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleUIManager : MonoBehaviour {

    #region Singleton
    public static BattleUIManager Instance { get; private set; }
    #endregion

    #region Attributs
    [SerializeField] protected Joystick joystick;
    [SerializeField] protected Button[] buttons;
    [SerializeField] protected TextMeshProUGUI battleInfo;
    [SerializeField] protected RectTransform heroHealth;
    [SerializeField] protected RectTransform heroStamina;
    [SerializeField] protected RectTransform villainHealth;

    public float Countdown { get; set; } = 3;
    #endregion

    #region Getter and Setter
    public Joystick Joystick {
        get { return joystick; }
        set { joystick = value; }
    }
    public Button[] Buttons {
        get { return buttons; }
        set { buttons = value; }
    }
    public TextMeshProUGUI BattleInfo {
        get { return battleInfo; }
        set { battleInfo = value; }
    }
    public RectTransform HeroHealth {
        get { return heroHealth; }
        set { heroHealth = value; }
    }
    public RectTransform HeroStamina {
        get { return heroStamina; }
        set { heroStamina = value; }
    }
    public RectTransform Villainhealth {
        get { return villainHealth; }
        set { villainHealth = value; }
    }
    #endregion

    #region Unity Methods
    // Awake is called when the script instance is being loaded
    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        Physics.gravity = new Vector3(0, -98.1f, 0);
        StartCoroutine(DisplayCountdown());
    }

    // Update is called once per frame
    void Update() {

    }
    #endregion

    #region Methods
    public Vector3 GetInputVector() {
        //Take Input from Joystick
        float horizontal = Joystick.Horizontal;
        float vertical = Joystick.Vertical;

        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, 0, vertical).normalized;
    }
    public bool IsInput() {
        Vector3 inputVector = GetInputVector();
        return (inputVector.x != 0 || inputVector.z != 0) ? true : false;
    }
    public IEnumerator FreezeGame(float freezeTime) {
        Time.timeScale = 0;
        float startTime = Time.realtimeSinceStartup;

        Buttons[0].interactable = false;
        Buttons[1].interactable = false;
        while(Time.realtimeSinceStartup < startTime + freezeTime) {
            yield return null;
        }
        Buttons[0].interactable = true;
        Buttons[1].interactable = true;

        Time.timeScale = 1;
    }
    public IEnumerator DisplayCountdown() {
        StartCoroutine(FreezeGame(Countdown));
        for(float countdownInfo = Countdown; countdownInfo > 0 ; countdownInfo--) {
            battleInfo.text = countdownInfo.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        battleInfo.text = string.Empty;
    }
    public IEnumerator DisplayBattleInfo(string info, float time) {
        StartCoroutine(FreezeGame(time));
        battleInfo.text = info.ToString();
        yield return new WaitForSecondsRealtime(time);

        battleInfo.text = string.Empty;
    }
    #endregion
}
