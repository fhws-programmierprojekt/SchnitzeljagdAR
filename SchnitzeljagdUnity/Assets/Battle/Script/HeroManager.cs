using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroController))]
public class HeroManager : VillainManager {

    #region Singleton
    public static new HeroManager Instance { get; private set; }
    #endregion

    #region Attributes
    [SerializeField] protected float stamina;
    protected float currentStamina;

    public int Deaths { get; set; } = 0;
    #endregion

    #region Getter and Setter
    public float Stamina {
        get { return stamina; }
        set { stamina = (value < 0) ? 0 : value; }
    }
    public float CurrentStamina {
        get { return currentStamina; }
        set { currentStamina = (value < 0) ? 0 : ((value > Stamina) ? Stamina : value); }
    }
    #endregion

    #region Unity Methods
    // Awake is called when the script instance is being loaded
    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        Opponent = BattleArenaManager.Instance.Villain;
        OpponentManager = Opponent.GetComponent<VillainManager>();
        Animator = GetComponent<Animator>();
        AnimationClips = Animator.runtimeAnimatorController.animationClips;
        currentHealth = health;
        currentStamina = stamina;
        InvokeRepeating("ReplenishStamina", 0, 1);
    }
    // Update is called once per frame
    void Update() {
        UpdateStats();
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.gameObject.name == "DeathFloor") {
            Deaths += 1;
            CurrentHealth = 0;
            StartCoroutine(BattleUIManager.Instance.DisplayBattleInfo("V E R L O R E N", 2));
            CurrentHealth = Health;
            CurrentStamina = Stamina;
            VillainManager.Instance.CurrentHealth = VillainManager.Instance.Health;
            transform.position = HeroController.Instance.SpawnPosition;
            Opponent.transform.position = VillainController.Instance.SpawnPosition;
        }
    }
    #endregion

    #region Methods
    protected override void UpdateStats() {
        BattleUIManager.Instance.HeroHealth.sizeDelta = new Vector2(100 / health * CurrentHealth * 10, 20);
        BattleUIManager.Instance.HeroStamina.sizeDelta = new Vector2(100 / stamina * CurrentStamina * 10, 20);
    }
    protected void ReplenishStamina() {
        CurrentStamina += 4;
    }
    #endregion
}
