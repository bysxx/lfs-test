using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFSM
{

    public BossFSM(Controller controller) {
        bossController = controller as BossController;
    }

    private BossController bossController;
    private State curState;

    public void Update() {
        curState?.Activate();
    }

    public void Transition(State state) {
        curState?.Exit();
        curState = state;
        curState.Enter(bossController);
    }
}
