
using UnityEngine;

public class GameManager : DontDestroySingleton<GameManager> {

    public bool isTutorialCleared;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.V)) {
            IHitable hitable = Access.Player.GetComponent<IHitable>();
            hitable.Hit(100);
        }
    }
}