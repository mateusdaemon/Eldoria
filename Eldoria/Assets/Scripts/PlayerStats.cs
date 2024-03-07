using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int maxLife = 20;
    private static int maxMana = 10;
    private static int life = 20;
    private static int mana = 10;

    public static int GetMaxMana()
    {
        return maxMana;
    }

    public static int GetMaxLife()
    {
        return maxLife;
    }

    public static int GetMana()
    {
        return mana;
    }

    public static int GetLife()
    {
        return life;
    }

    public static void DropMana(int drop)
    {
        mana -= drop;
    }

    public static void AddMana(int add)
    {
        mana += add;
    }

    public static void DropLife(int drop)
    {
        life -= drop;
    }

    public static void AddLife(int add)
    {
        life += add;
    }

}
