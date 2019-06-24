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
    [SerializeField] protected Button button;
    [SerializeField] protected TextMeshProUGUI buttonInfo;
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
    public Button Button {
        get { return button; }
        set { button = value; }
    }
    public TextMeshProUGUI ButtonInfo {
        get { return buttonInfo; }
        set { buttonInfo = value; }
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
        UpdateButton();
    }
    #endregion

    #region Methods
    public Vector3 GetInputVector() {
        //Take Input from Joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, 0, vertical).normalized;
    }
    public bool isInput() {
        Vector3 inputVector = GetInputVector();
        return (inputVector.x != 0 || inputVector.z != 0) ? true : false;
    }
    protected void UpdateButton() {
        Vector3 inputVector = GetInputVector();
        Vector3 forwardVector = BattleArenaManager.Instance.Hero.transform.forward;

        bool isForward = MyGeometry.IsWithinAngle(forwardVector, inputVector, -45, 45);
        if(isForward) {
            ButtonInfo.text = "Attack";
        } else {
            ButtonInfo.text = "Evade";
        }
    }
    public IEnumerator FreezeGame(float freezeTime) {
        Time.timeScale = 0;
        float startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < startTime + freezeTime) {
            yield return null;
        }
        Time.timeScale = 1;
    }
    private IEnumerator DisplayCountdown() {
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
