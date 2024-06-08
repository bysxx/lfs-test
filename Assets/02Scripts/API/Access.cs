using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// You can use this class to reference objects that are configured as singletons.
/// </summary>
public static class Access {

    /// <summary>
    /// Global Player
    /// </summary>
    public static PlayerController Player { get { return PlayerController.Instance; } }

    /// <summary>
    /// UIManager
    /// </summary>
    public static UIManager UIM { get { return UIManager.Instance; } }

    /// <summary>
    /// QuestManager
    /// </summary>
    public static QuestManager QuestM { get { return QuestManager.Instance; } }

    /// <summary>
    /// DialogueManager
    /// </summary>
    public static DialogueManager DIalogueM { get { return DialogueManager.Instance; } }

    /// <summary>
    /// BossStageManager
    /// </summary>
    public static BossStageManager BossStageM { get { return BossStageManager.Instance; } }

    /// <summary>
    /// GameManager
    /// </summary>
    public static GameManager GameM { get { return GameManager.Instance; } }
}
