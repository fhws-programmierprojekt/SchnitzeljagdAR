using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleArenaManager {

    //attributes
    public GameObject Arena { get; set; }
    public GameObject DeathFloor { get; set; }

    private readonly Material stonewall = Resources.Load<Material>("Textures/StoneWall");

    //constructors
    public BattleArenaManager() {
        ReferenceElements();
    }

    //methods
    private void ReferenceElements() {
        Arena = GameObject.Find("BattleArena");
        Arena.GetComponent<Renderer>().material = stonewall;

        DeathFloor = GameObject.Find("DeathFloor");
    }
}
