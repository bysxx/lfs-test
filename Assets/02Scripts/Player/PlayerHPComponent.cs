using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPComponent : MonoBehaviour, IHitable {

    [SerializeField] private int hp;

    public void Hit(int dmg) {
        hp -= dmg;
        if (hp <= 0) {
            hp = 0;
            Dead();
        }
    }

    public void Dead() {
        Access.Player.StopPlayer();
        Access.UIM.FadeInOut("Review");
    }
}
