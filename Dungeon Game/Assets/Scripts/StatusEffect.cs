using UnityEngine;

public abstract class StatusEffect
{
    //start of turn or end of turn, do effect
    [SerializeField]
    public bool startOfTurn = true;

    //how the status effect should effect the enemy and its stats
    public abstract void DoEffect(Stats enemyStats);

}
