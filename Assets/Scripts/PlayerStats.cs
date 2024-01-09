using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int _money;

    public int startMoney = 400;

    public static int _lives;
    public int startLives = 20;

    public static int _rounds;

    private void Start()
    {
        _rounds = 0;
        _money = startMoney;
        _lives = startLives;
    }
}
