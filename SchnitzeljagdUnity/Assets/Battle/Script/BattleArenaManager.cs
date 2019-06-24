using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleArenaManager : MonoBehaviour{

    #region Singleton
    private static BattleArenaManager instance;
    public static BattleArenaManager GetInstance() {
        return instance;
    }
    #endregion

    #region Attributes
    [SerializeField] protected GameObject battleArena;
    [SerializeField] protected GameObject deathFloor;
    [SerializeField] protected GameObject hero;
    [SerializeField] protected GameObject villain;
    #endregion

    #region Getter and Setter
    public GameObject BattleArena {
        get { return battleArena; }
        set { battleArena = value; }
    }
    public GameObject DeathFloor {
        get { return deathFloor; }
        set { deathFloor = value; }
    }
    public GameObject Hero {
        get { return hero; }
        set { hero = value; }
    }
    public GameObject Villain {
        get { return villain; }
        set { villain = value; }
    }
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        
    }
    #endregion

    #region Methods

    #endregion
}
