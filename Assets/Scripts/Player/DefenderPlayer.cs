using UnityEngine;

public class DefenderPlayer : NetworkPlayer
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void OnSpawned()
    {
        base.OnSpawned();
    }
    public override void Update()
    {
        base.Update();

        
    }
}
