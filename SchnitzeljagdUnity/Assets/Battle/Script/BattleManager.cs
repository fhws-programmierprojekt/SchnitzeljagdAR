using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private BattleArenaManager BattleArenaManager { get; set; }

    // Start is called before the first frame update
    void Start() {
        BattleArenaManager = new BattleArenaManager();
    }
    // Update is called once per frame
    void Update() {

    }
}
