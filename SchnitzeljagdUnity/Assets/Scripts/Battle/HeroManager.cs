﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(HeroController))]
public class HeroManager : VillainManager {

    #region Singleton
    public static new HeroManager Instance { get; private set; }
    #endregion

    #region Attributes
    [SerializeField] protected float stamina;
    protected float currentStamina;
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

        CurrentHealth = Health;
        CurrentStamina = Stamina;
        InvokeRepeating("ReplenishStamina", 0, 1);
    }
    // Update is called once per frame
    void Update() {
        UpdateStats();
        IsHealthDepleted();
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.gameObject.name == "DeathFloor") {
            StartCoroutine(Death());
        }
    }
    #endregion

    #region Methods
    protected override void UpdateStats() {
        BattleUIManager.Instance.HeroHealth.sizeDelta = new Vector2(100 / health * CurrentHealth * 10, 20);
        BattleUIManager.Instance.HeroStamina.sizeDelta = new Vector2(100 / stamina * CurrentStamina * 10, 20);
    }
    public void ReplenishStamina() {
        CurrentStamina += 6;
    }
    public override void AttackCheck() {
        float staminaCost = 16;
        float distance = Vector3.Distance(transform.position, Opponent.transform.position);
        if(CurrentStamina > staminaCost && distance < AttackRange && !Animator.GetBool("isAttackMeele") && !Animator.GetBool("isAttackThrust")) {
            CurrentStamina -= staminaCost;
            StartCoroutine(Attack("AttackMeele", AttackDamage * 0.6f));
        } else if(CurrentStamina > staminaCost && !Animator.GetBool("isAttackMeele") && !Animator.GetBool("isAttackThrust")) {
            CurrentStamina -= staminaCost;
            StartCoroutine(Attack("AttackThrust", AttackDamage));
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * 4;
        }
    }
    protected IEnumerator Attack(string attackName, float damage) {

        Animator.SetBool("is" + attackName, true);
        float attackTime = GetAnimationTime(attackName) - 1;
        yield return new WaitForSeconds(attackTime * 0.4f);
        if(Vector3.Distance(transform.position, Opponent.transform.position) < AttackRange) {
            OpponentManager.CurrentHealth = OpponentManager.CurrentHealth - damage;
        }
        yield return new WaitForSeconds(attackTime * 0.6f);

        Animator.SetBool("is" + attackName, false);
    }
    protected override IEnumerator Death() {
        Deaths += 1;
        CurrentHealth = 0;
        CurrentStamina = 0;
        StartCoroutine(BattleUIManager.Instance.DisplayBattleInfo("V E R L O R E N", 4));
        yield return new WaitForSecondsRealtime(2);
        CurrentHealth = Health;
        CurrentStamina = Stamina;
        VillainManager.Instance.CurrentHealth = VillainManager.Instance.Health;
        transform.position = HeroController.Instance.SpawnPosition;
        Opponent.transform.position = VillainController.Instance.SpawnPosition;
    }
    #endregion
}
