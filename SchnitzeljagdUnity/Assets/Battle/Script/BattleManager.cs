using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private BattleArenaManager BattleArenaManager { get; set; }

    private Combatant Hero { get; set; }
    private Combatant Villain { get; set; }

    // Start is called before the first frame update
    void Start() {
        BattleArenaManager = new BattleArenaManager();
        SetCombatants();
    }
    // Update is called once per frame
    void Update() {
        Hero.Update();
        Villain.Update();
    }

    private void SetCombatants() {
        GameObject hero = GameObject.Find("Hero");
        GameObject villain = GameObject.Find("Villain");

        Hero = new CombatantController(hero, hero.transform.position, 6);
        Villain = new Combatant(villain, villain.transform.position, 4);

        Hero.Opponent = Villain;
        Villain.Opponent = Hero;
    }
}
