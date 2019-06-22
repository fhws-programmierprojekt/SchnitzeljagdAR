using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    //Attributes 
    public GameObject opponent;
    private CombatManager opponentCombatManager;
    private Animator animator;

    public GameObject healthbar;
    private RectTransform healthbarRectTransform;
    public float health;
    private float currentHealth;


    public float attackCooldown;
    private float currentAttackCooldown;

    public float attackSpinRange;

    //Getter and Setter
    public float Health {
        get { return health; }
        set { health = value; }
    }

    // Start is called before the first frame update
    void Start() {
        opponentCombatManager = opponent.GetComponent<CombatManager>();
        animator = GetComponent<Animator>();
        healthbarRectTransform = healthbar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        healthbarRectTransform.sizeDelta = new Vector2(Health * 10, 20);
        AttackCheck();
    }

    public void AttackCheck() {
        if(currentAttackCooldown > 0) {
            currentAttackCooldown -= Time.deltaTime;
        } else if(Vector3.Distance(transform.position, opponent.transform.position) < attackSpinRange) {
            AttackSpin(10);
        }
    }
    public void AttackDash() {

    }
    public void AttackSpin(int damage) {
        currentAttackCooldown = attackCooldown;
        StartCoroutine(AttackAnimation("AttackSpin", 1, damage));
    }

    IEnumerator AttackAnimation(string attackName, float attackDuration, float damage) {
        string isAttackParameter = "is" + attackName;
        animator.SetBool(isAttackParameter, true);
        //animator.Play(attackName);
        GameObject.Find("AttackSpin").GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(attackDuration);

        float distance = Vector3.Distance(transform.position, opponent.transform.position);
        if(distance < attackSpinRange) {
            opponentCombatManager.Health = opponentCombatManager.Health - damage;
        }
        animator.SetBool(isAttackParameter, false);
        GameObject.Find("AttackSpin").GetComponent<SpriteRenderer>().enabled = false;
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackSpinRange);
    }

    private void AddAttackSpinVisual() {
        gameObject.AddComponent<SpriteRenderer>();
        SpriteRenderer attackSpinVisual = GetComponent<SpriteRenderer>();
    }
}
