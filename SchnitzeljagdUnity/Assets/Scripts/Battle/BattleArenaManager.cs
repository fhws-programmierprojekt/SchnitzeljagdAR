﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleArenaManager : MonoBehaviour {

    #region Singleton
    public static BattleArenaManager Instance { get; private set; }
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
    // Awake is called when the script instance is being loaded
    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start() {

    }
    // Update is called once per frame
    void Update() {
        
    }
    #endregion

    #region Methods

    #endregion
}
