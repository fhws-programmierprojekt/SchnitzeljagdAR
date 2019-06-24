using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroManager))]
public class HeroController : VillainController {

    #region Singleton
    public static new HeroController Instance { get; private set; }
    #endregion

    #region Attributes
    public float evadeDistance;
    #endregion

    #region Unity Methods
    // Awake is called when the script instance is being loaded
    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        Opponent = BattleArenaManager.Instance.Villain;
        SpawnPosition = transform.position;
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update() {
        Animator.SetBool("isPulling", true);
        Movement();
        Rotation();

        if(Input.GetKeyDown(KeyCode.Space)) {
            Evade();
        }
    }
    #endregion

    #region Methods
    protected override void Movement() {
        Vector3 directionVector = BattleUIManager.Instance.GetInputVector();

        if(directionVector.x != 0 || directionVector.z != 0 ) {
            AnimationMovementDirection(directionVector);
            Vector3 movementVector = directionVector * Time.deltaTime * movementSpeed;
            Rigidbody.MovePosition(transform.position + movementVector);
        } else {
            SetIsWalkingFalse();
        }
    }

    private void AnimationMovementDirection(Vector3 directionVector) {

        SetIsWalkingFalse();
        if(MyGeometry.IsWithinAngle(directionVector, transform.forward, -45, 45)) {
            Animator.SetBool("isSwordWalking", true);
        }else if(MyGeometry.IsWithinAngle(directionVector, transform.forward, 135, -135)) {
            Animator.SetBool("isSwordWalkingBack", true);
        }else if(MyGeometry.IsWithinAngle(directionVector, transform.forward, 45, 135)) {
            Animator.SetBool("isSwordWalkingLeft", true);
        }else if(MyGeometry.IsWithinAngle(directionVector, transform.forward, -135, -45)) {
            Animator.SetBool("isSwordWalkingRight", true);
        }
    }
    private void SetIsWalkingFalse() {
        Animator.SetBool("isSwordWalking", false);
        Animator.SetBool("isSwordWalkingBack", false);
        Animator.SetBool("isSwordWalkingLeft", false);
        Animator.SetBool("isSwordWalkingRight", false);
    }

    public void Evade() {
        Rigidbody.velocity = BattleUIManager.Instance.GetInputVector() * 24;

        //transform.position += GetDirectonVector() * evadeDistance;
        //body.AddForce(GetDirectonVector() * evadeDistance, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.gameObject.name == "DeathFloor") {
            HeroManager.Instance.CurrentHealth = 0;
            StartCoroutine(BattleUIManager.Instance.DisplayBattleInfo("V E R L O R E N", 2));
            HeroManager.Instance.CurrentHealth = HeroManager.Instance.Health;
            transform.position = SpawnPosition;
            Opponent.transform.position = VillainController.Instance.SpawnPosition;
        }
    }
    #endregion
}
