using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    //Attributes 
    public GameObject opponent;
    private CombatManager opponentCombatManager;

    private Animator animator;
    private AnimationClip[] animationClips;

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
        opponentCombatManager = opponent.GetComponent<CombatManager>();
        animator = GetComponent<Animator>();
        animationClips = animator.runtimeAnimatorController.animationClips;
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
        } else if(Vector3.Distance(transform.position, opponent.transform.position) < attackRange/2) {
            AttackSpin(10);
        }
    }
    public void AttackDash() {

    }
    public void AttackSpin(int damage) {
        currentAttackCooldown = attackCooldown;
        StartCoroutine(AttackAnimation("AttackSpin", damage));
    }

    IEnumerator AttackAnimation(string attackName, float damage) {

        float attackTime = GetAnimationTime(attackName) - 0.40f;

        string isAttackParameter = "is" + attackName;
        animator.SetBool(isAttackParameter, true);
        GameObject.Find(attackName).GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(attackTime / 2);
        float distance = Vector3.Distance(transform.position, opponent.transform.position);
        if(distance < attackRange) {
            opponentCombatManager.Health = opponentCombatManager.Health - damage;
        }

        yield return new WaitForSeconds(attackTime / 2);
        animator.SetBool(isAttackParameter, false);
        GameObject.Find(attackName).GetComponent<SpriteRenderer>().enabled = false;
    }

    private float GetAnimationTime(string animationName) {
        float animationTime = -1;
        foreach(AnimationClip clip in animationClips) {
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



    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
