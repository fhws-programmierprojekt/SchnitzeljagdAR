using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VillainController))]
public class VillainManager : MonoBehaviour {

    #region Singleton
    public static VillainManager Instance { get; private set; }
    #endregion

    #region Attributes
    [SerializeField] protected float attackRange;
    [SerializeField] protected float health;
    protected float currentHealth;

    private float AttackCooldown { get; set; } = 6;
    private float CurrentAttackCooldown { get; set; }
    public GameObject Opponent { get; set; }
    public VillainManager OpponentManager { get; set; }
    public Animator Animator { get; set; }
    public AnimationClip[] AnimationClips { get; set; }
    #endregion

    #region Getter and Setter
    public float AttackRange {
        get { return attackRange; }
        set { attackRange = value; }
    }
    public float Health {
        get { return health; }
        set { health = (value < 10) ? 10 : value; }
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
        currentHealth = health;
    }

    // Update is called once per frame
    void Update() {
        UpdateStats();
        AttackCheck();
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
            StartCoroutine(AttackSpin("AttackSpin", 20));
        } else if(Random.Range(0, 1000) <= 4){
            CurrentAttackCooldown = AttackCooldown;
            StartCoroutine(AttackThrust("AttackThrust"));
        }
    }
    protected IEnumerator AttackSpin(string attackName, float damage) {
        SpriteRenderer attackSprite = GameObject.Find("AttackSpin").GetComponent<SpriteRenderer>();
        attackSprite.enabled = true;

        VillainController.Instance.RotationSpeed = 0;
        Animator.SetBool("is" + attackName, true);
        float attackTime = GetAnimationTime(attackName) - 0.40f;
        yield return new WaitForSeconds(attackTime * 0.6f);
        if(Vector3.Distance(transform.position, Opponent.transform.position) < AttackRange) {
            OpponentManager.CurrentHealth = OpponentManager.CurrentHealth - damage;
        }
        attackSprite.enabled = false;

        yield return new WaitForSeconds(attackTime * 0.4f);
        Animator.SetBool("is" + attackName, false);
        VillainController.Instance.RotationSpeed = 100;
    }
    protected IEnumerator AttackThrust(string attackName) {
        SpriteRenderer attackSprite = GameObject.Find("AttackThrust").GetComponent<SpriteRenderer>();
        BoxCollider attackCollider = GameObject.Find("AttackThrust").GetComponent<BoxCollider>();
        attackSprite.enabled = true;

        VillainController.Instance.RotationSpeed = 0;
        Animator.SetBool("is" + attackName, true);
        float attackTime = GetAnimationTime(attackName) - 0.40f;
        yield return new WaitForSeconds(attackTime * 0.4f);
        attackCollider.enabled = true;
        yield return new WaitForSeconds(attackTime * 0.6f);

        attackCollider.enabled = false;
        attackSprite.enabled = false;
        Animator.SetBool("is" + attackName, false);
        VillainController.Instance.RotationSpeed = 100;
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
    #endregion
}
