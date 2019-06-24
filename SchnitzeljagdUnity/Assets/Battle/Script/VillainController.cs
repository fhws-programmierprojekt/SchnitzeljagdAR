using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VillainManager))]
public class VillainController : MonoBehaviour {

    #region Singleton
    public static VillainController Instance { get; private set; }
    #endregion

    #region Attributes
    public float movementSpeed;
    public float RotationSpeed { get; set; } = 100;

    public GameObject Opponent { get; set; }
    public Vector3 SpawnPosition { get; set; }
    public Animator Animator { get; set; }
    public Rigidbody Rigidbody { get; set; }
    #endregion

    #region Getter and Setter

    #endregion

    #region Unity Methods
    // Awake is called when the script instance is being loaded
    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        Opponent = BattleArenaManager.Instance.Hero;
        SpawnPosition = transform.position;
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Movement();
        Rotation();
    }
    #endregion

    #region Methods
    protected virtual void Movement() {

        // Calculate the distance between this and opponent
        float distance = Vector3.Distance(transform.position, Opponent.transform.position);

        if(distance > 3 && !Animator.GetBool("isAttackSpin") && !Animator.GetBool("isAttackThrust")) {
            MovementAnimation();
            Vector3 directionVector = MyGeometry.GetDirectionVector(transform.position, Opponent.transform.position);
            Vector3 movementVector = directionVector * Time.deltaTime * movementSpeed;
            Rigidbody.MovePosition(transform.position + movementVector);
        } else {
            SetIsWalkingFalse();
        }
    }
    protected void MovementAnimation() {
        SetIsWalkingFalse();
        Animator.SetBool("isSwordWalking", true);

    }
    protected virtual void SetIsWalkingFalse() {
        Animator.SetBool("isSwordWalking", false);
    }
    protected void Rotation() {
        Quaternion rotationQuaternion = MyGeometry.GetRotationQuaternion(gameObject, Opponent, RotationSpeed);
        Rigidbody.MoveRotation(rotationQuaternion);
    }
    #endregion
}
