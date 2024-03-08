using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int maxLife = 20;
    private static int maxMana = 10;
    private static int life = 20;
    private static int mana = 10;
    private static bool redCursed;
    private static bool greenCursed;
    private static bool blueCursed;

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

    public static void SetLife(int lifeTotal)
    {
        life = lifeTotal;
    }

    public static void SetMana(int manaTotal)
    {
        mana = manaTotal;
    }

    public static bool RedCursed()
    {
        return redCursed;
    }

    public static bool GreenCursed()
    {
        return greenCursed;
    }

    public static bool BlueCursed()
    {
        return blueCursed;
    }

    public static void CurseRed(bool curse)
    {
        redCursed = curse;
    }
    public static void CurseGreen(bool curse)
    {
        greenCursed = curse;
    }

    public static void CurseBlue(bool curse)
    {
        blueCursed = curse;
    }

}
