using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    // Player stats
    private static float maxLife = 10;
    private static float maxMana = 20;
    private static float life = 10;
    private static float mana = 20;
    private static float playerDamage = 2;

    // Player states
    private static bool redCursed = false;
    private static bool greenCursed = false;
    private static bool blueCursed = false;
    private static bool canShoot = true;
    private static bool canMove = true;
    private static bool skillsEnable = false;


    // Shield states
    private static bool neutralShielded = false;
    private static bool redShielded = false;
    private static bool greenShielded = false;
    private static bool blueShielded = false;

    // Global utilities
    public enum Direction {Right, Left, Front, Back };

    public static float GetMaxMana()
    {
        return maxMana;
    }

    public static float GetMaxLife()
    {
        return maxLife;
    }

    public static float GetMana()
    {
        return mana;
    }

    public static float GetLife()
    {
        return life;
    }

    public static void DropMana(float drop)
    {
        mana -= drop;
    }

    public static void AddMana(float add)
    {
        mana += add;
    }

    public static void DropLife(float drop)
    {
        life -= drop;
    }

    public static void AddLife(float add)
    {
        life += add;
    }

    public static void SetLife(float lifeTotal)
    {
        life = lifeTotal;
    }

    public static void SetMana(float manaTotal)
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

    public static void SetShoot(bool shoot)
    {
        canShoot = shoot;
    }

    public static bool CanShoot()
    {
        return canShoot;
    }

    public static void SetDamage(float newDamage)
    {
        playerDamage = newDamage;
    }

    public static float GetDamage()
    {
        return playerDamage;
    }
    public static void SetMove(bool move)
    {
        canMove = move;
    }

    public static bool CanMove()
    {
        return canMove;
    }

    public static bool IsNeutralShielded()
    {
        return neutralShielded;
    }

    public static void SetNeutralShielded(bool shield)
    {
        neutralShielded = shield;
    }

    public static bool IsRedShielded()
    {
        return redShielded;
    }

    public static void SetRedShielded(bool shield)
    {
        redShielded = shield;
    }

    public static bool IsGreenShielded()
    {
        return greenShielded;
    }

    public static void SetGreenShielded(bool shield)
    {
        greenShielded = shield;
    }

    public static bool IsBlueShielded()
    {
        return blueShielded;
    }

    public static void SetBlueShielded(bool shield)
    {
        blueShielded = shield;
    }

    public static void EnableSkill(bool enable)
    {
        skillsEnable = enable;
    }

    public static bool SkillEnable()
    {
        return skillsEnable;
    }
}
