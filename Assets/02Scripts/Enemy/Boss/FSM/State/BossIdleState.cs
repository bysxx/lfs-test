using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : State {

    private BossController bossController;
    private int i = 0;

    public override void Activate() {
        
    }

    public override void Enter(Controller controller) {
        bossController = controller as BossController;

        if (!TutorialManager.isTutorialCleared) return;
        if (bossController.Hp.Accessor <= 0) return;

        StartCoroutine(SetPattern(i));
        i++;
        i = i % 2;
    }

    public override void Exit() {
        bossController = null;
    }

    private IEnumerator SetPattern(int i) {
        yield return new WaitForSeconds(3f);
        bossController.SetPattern(i);
    }
}
