using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue {
    [CreateAssetMenu(menuName = "Dialogue/AcceptionCondition/PlayerDontMoveCondition", fileName = "PlayerDontMoveCondition")]
    public class PlayerDontMoveCondition : DialogueAcceptionCondition {

        [SerializeField] Quest quest;
        public override bool IsPass(DialogueGraph dialogue) {
            return Access.Player.CanMove;
        }

    }
}
