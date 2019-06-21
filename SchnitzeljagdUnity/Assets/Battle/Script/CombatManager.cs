using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    //Attributes 
    public GameObject opponent;
    private CombatManager opponentCombatManager;

    public GameObject healthbar;
    private RectTransform healthbarRectTransform;
    public float health;
    private float currentHealth;

    public float attackRange;
    public float attackCooldown;
    private float currentAttackCooldown;

    //Getter and Setter
    public float Health {
        get { return health; }
        set { health = value; }
    }

    // Start is called before the first frame update
    void Start() {
        healthbarRectTransform = healthbar.GetComponent<RectTransform>();
        opponentCombatManager = opponent.GetComponent<CombatManager>();
    }

    // Update is called once per frame
    void Update() {
        healthbarRectTransform.sizeDelta = new Vector2(Health * 10, 20);
        AttackCheck();
    }

    public void AttackCheck() {
        if(currentAttackCooldown > 0) {
            currentAttackCooldown -= Time.deltaTime;
        } else if(Vector3.Distance(transform.position, opponent.transform.position) < attackRange) {
            AttackSpin(10);
        }
    }
    public void AttackDash() {

    }
    public void AttackSpin(int damage) {
        opponentCombatManager.Health = opponentCombatManager.Health - damage;
        currentAttackCooldown = attackCooldown;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
