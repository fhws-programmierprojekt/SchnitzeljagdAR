using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(VillainController))]
public class VillainManager : MonoBehaviour {

    #region Singleton
    public static VillainManager Instance { get; private set; }
    #endregion

    #region Attributes
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float health;
    protected float currentHealth;

    private float AttackCooldown { get; set; } = 5;
    private float CurrentAttackCooldown { get; set; }
    public GameObject Opponent { get; set; }
    public VillainManager OpponentManager { get; set; }
    public Animator Animator { get; set; }
    public AnimationClip[] AnimationClips { get; set; }
    public SpriteRenderer AttackSpinSprite { get; set; }
    #endregion

    #region Getter and Setter
    public float AttackRange {
        get { return attackRange; }
        set { attackRange = value; }
    }
    public float AttackDamage {
        get { return attackDamage; }
        set { attackDamage = value; }
    }
    public float Health {
        get { return health; }
        set { health = (value < 1) ? 1 : value; }
    }
    public float CurrentHealth {
        get { return currentHealth; }
        set { currentHealth = (value < 0) ? 0 : ((value > Health) ? Health : value); }
    }
    #endregion

    #region Unity Methods
    // Awake is called when the script instance is being loaded
    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        Opponent = BattleArenaManager.Instance.Hero;
        OpponentManager = Opponent.GetComponent<VillainManager>();
        Animator = GetComponent<Animator>();
        AnimationClips = Animator.runtimeAnimatorController.animationClips;
        AttackSpinSprite = GameObject.Find("AttackSpin").GetComponent<SpriteRenderer>();
        AttackSpinSprite.enabled = false;

        CurrentHealth = Health;
    }

    // Update is called once per frame
    void Update() {
        UpdateStats();
        AttackCheck();
        IsHealthDepleted();
        UpdateAttackSprite();
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
    #endregion

    #region Methods
    protected virtual void UpdateStats() {
        BattleUIManager.Instance.Villainhealth.sizeDelta = new Vector2(100 / Health * CurrentHealth * 10, 20);
    }
    public virtual void AttackCheck() {
        if(CurrentAttackCooldown > 0) {
            CurrentAttackCooldown -= Time.deltaTime;
        } else if(Vector3.Distance(transform.position, Opponent.transform.position) < AttackRange) {
            CurrentAttackCooldown = AttackCooldown;
            StartCoroutine(AttackSpin(AttackDamage));
        }
    }
    protected IEnumerator AttackSpin(float damage) {
        AttackSpinSprite.enabled = true;

        Animator.SetBool("isAttackSpin", true);
        float attackTime = GetAnimationTime("AttackSpin") - 0.4f;
        yield return new WaitForSeconds(attackTime * 0.6f);
        if(Vector3.Distance(transform.position, Opponent.transform.position) < AttackRange) {
            OpponentManager.CurrentHealth = OpponentManager.CurrentHealth - damage;
        }
        AttackSpinSprite.enabled = false;

        yield return new WaitForSeconds(attackTime * 0.4f);
        Animator.SetBool("isAttackSpin", false);
    }
    protected void UpdateAttackSprite() {
        if(Animator.GetBool("isAttackSpin")) {
            AttackSpinSprite.enabled = true;
        } else {
            AttackSpinSprite.enabled = false;
        }
    }
    protected float GetAnimationTime(string animationName) {
        float animationTime = -1;
        foreach(AnimationClip clip in AnimationClips) {
            if(clip.name == animationName) {
                animationTime = clip.length;
                break;
            }
        }
        if (animationTime < 0) {
            Debug.Log("No Animation found with the name: " + animationName);
        }
        return animationTime;
    }
    protected void IsHealthDepleted() {
        if(CurrentHealth == 0) {
            Time.timeScale = 0;
            StartCoroutine(Death());
        }
    }
    protected virtual IEnumerator Death() {
        VillainController.Instance.MovementSpeed = 0;
        VillainController.Instance.RotationSpeed = 0;
        Animator.SetBool("isDying", true);
        AddPoints();
        StartCoroutine(BattleUIManager.Instance.DisplayBattleInfo("G E W O N N E N", 4));
        yield return new WaitForSecondsRealtime(2);
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene(QuestHubController.questHubController.currentQuest);
    }
    private void AddPoints() {
        int points = 300;
        int penalty = HeroManager.Instance.Deaths * 25;
        points = (points - penalty >= 100) ? points - penalty : 100;
        if(QuestHubController.questHubController != null) {
            QuestHubController.questHubController.AddPoints(points);
        }
        PointsGainController pointController = GameObject.Find("PointController").GetComponent<PointsGainController>();
        pointController.playPointAnimation(points);
    }
    #endregion
}
