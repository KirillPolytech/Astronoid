using UnityEngine;
using Zenject;

public class DivisionBallsBuff : Buff
{
    private BallPool _ballPool;

    [Inject]
    public void Construct(BallPool ballPool)
    {
        _ballPool = ballPool;
    }

    public override void Execute()
    {
        if (!gameObject.activeSelf)
            return;
        
        Ball[] balls = _ballPool.GetActive();

        foreach (var ball in balls)
        {
            Ball temp = _ballPool.Pop();
            
            if (temp == null)
                break;

            Vector3 pos = ball.Rb.position + ball.Transform.right;
            Vector3 velocity = (Vector3.up * Random.Range(-1, 2f) + Vector3.right * Random.Range(-1, 2f)).normalized *
                               ball.Rb.velocity.magnitude;
            temp.Initialize(velocity, pos);
        }

        gameObject.SetActive(false);
    }
}