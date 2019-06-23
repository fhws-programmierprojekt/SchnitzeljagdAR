using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroController))]
public class HeroManager : VillainManager {

    //Attributes
    public GameObject staminaBar;
    protected RectTransform staminaBarRectTransform;
    public float stamina;
    protected float currentStamina;

    // Start is called before the first frame update
    void Start() {
        opponentVillainManager = opponent.GetComponent<VillainManager>();
        animator = GetComponent<Animator>();
        animationClips = animator.runtimeAnimatorController.animationClips;
        healthBarRectTransform = healthBar.GetComponent<RectTransform>();
        staminaBarRectTransform = staminaBar.GetComponent<RectTransform>();
        currentHealth = health;
        currentStamina = stamina;
    }

    // Update is called once per frame
    void Update() {
        healthBarRectTransform.sizeDelta = new Vector2(100 / health * currentHealth * 10, 20);
        staminaBarRectTransform.sizeDelta = new Vector2(100 / stamina * currentStamina * 10, 20);
    }
}
