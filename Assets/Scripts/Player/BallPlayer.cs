using UnityEngine;

public class BallPlayer : NetworkPlayer
{
    public float BounceStrength = 20.0f;
    public float GroundBounceDist = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void OnSpawned()
    {
        base.OnSpawned();
    }

    protected override void UpdateOnGround(Vector3 localMoveDir, bool isJumping)
    {
        base.UpdateOnGround(localMoveDir, isJumping);

        //Check for the ground below the player
        m_CenterHeight = transform.position.y;

        float footHeight = FootLocationObj.transform.position.y;

        float halfCapsuleHeight = m_CenterHeight - footHeight;

        Vector3 rayStart = transform.position;
        rayStart.y += GroundCheckStartOffsetY;

        Debug.Log(rayStart);

        Vector3 rayDir = Vector3.down;

        float rayDist = halfCapsuleHeight + GroundCheckStartOffsetY - CheckForGroundRadius;

        //Find all of the surfaces overlapping the sphere cast
        RaycastHit hitInfo;

        Physics.SphereCast(rayStart, CheckForGroundRadius, rayDir, out hitInfo, rayDist, m_GroundCheckMask);
        Debug.DrawRay(rayStart, rayDir * rayDist, Color.red);

        if (hitInfo.collider != null && hitInfo.distance <= GroundBounceDist)
        {
            m_RigidBody.AddForce(hitInfo.normal * BounceStrength, ForceMode.Impulse);
        }
    }
}