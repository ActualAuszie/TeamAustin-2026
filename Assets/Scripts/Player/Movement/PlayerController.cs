using System;
using System.Collections.Generic;
using UnityEngine;


public interface PlayerController
{
    void Init(NetworkPlayer player);

    void UpdateControls();

    void SetFacingDirection(Vector3 direction);

    void AddLedgeDir(Vector3 ledgeDir);
    
    Vector3 GetControlRotation();

    Vector3 GetMoveInput();

    Vector3 GetLookInput();

    bool IsJumping();
    
    bool IsFiring();

}
