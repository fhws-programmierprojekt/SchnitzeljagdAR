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
    [SerializeField] protected GameObject searchingImage;

    public bool IsRunning { get; set; } = false;
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
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    // Update is called once per frame
    void Update() {
        ImageTargetFound();
    }
    #endregion

    #region Methods
    // Time Freeze Methods
    public void ImageTargetFound() {
        if(BattleArenaManager.Instance.BattleArena.gameObject.GetComponent<MeshRenderer>().enabled == true) {
            searchingImage.SetActive(false);

            if(!IsRunning) {
                StartCoroutine(DisplayCountdown());
                IsRunning = true;
            }
        } else {
            searchingImage.SetActive(true);

            IsRunning = false;
            Time.timeScale = 0;
            Buttons[0].interactable = false;
            Buttons[1].interactable = false;
        }
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
    public IEnumerator FreezeGame(float freezeTime) {
        Time.timeScale = 0;
        Buttons[0].interactable = false;
        Buttons[1].interactable = false;

        float startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < startTime + freezeTime) {
            yield return null;
        }

        Time.timeScale = 1;
        Buttons[0].interactable = true;
        Buttons[1].interactable = true;
    }
    // Controller Input Methods
    public Vector3 GetInputVector() {
        //Take Input from Joystick
        float horizontal = Joystick.Horizontal;
        float vertical = Joystick.Vertical;

        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        Vector3 inputVector = new Vector3(horizontal, 0, vertical);
        inputVector = MyGeometry.InputRelativeToCamera(inputVector);
        return inputVector.normalized;
    }
    public bool IsInput() {
        Vector3 inputVector = GetInputVector();
        return (inputVector.x != 0 || inputVector.z != 0) ? true : false;
    }
    #endregion
}
