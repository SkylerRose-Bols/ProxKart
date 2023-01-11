using UnityEngine;
using Fusion;

public class SpikyBallPowerup : SpawnedPowerup {

    public new Collider collider;
    public float enableDelay = 0.5f;
    public float ballSpeed = 1f;

    KartEntity spawner = null;
    Transform child = null;
    Rigidbody rb = null;

    NetworkTransform nt = null;

    private void Awake() 
    {
        //
        // We start the collider off as disabled, because the object may be predicted, so it takes time for FUN methods
        // to be called on this object. When the object has Spawned(), then the collider will be enabled.
        //
        
        collider.enabled = true;
        child = transform.GetChild(0);
        rb = GetComponent<Rigidbody>();
    }

    public override void Init(KartEntity spawner)
    {
        base.Init(spawner);

        this.spawner = spawner;
    }

    public override void Spawned() 
    {
        base.Spawned();

        rb.AddForce(transform.forward * ballSpeed, ForceMode.VelocityChange);
        nt = GetComponent<NetworkTransform>();

        AudioManager.PlayAndFollow("bananaDropSFX", transform, AudioManager.MixerTarget.SFX);
    }

    public override void FixedUpdateNetwork() 
    {
        base.FixedUpdateNetwork();
    }

    public override bool Collide(KartEntity kart) 
    {
        if(kart == spawner || Object.IsValid && !HasInit)
        {
            return false;
        }

        kart.SpinOut();

        Runner.Despawn(Object, true);

        return true;
    }
}