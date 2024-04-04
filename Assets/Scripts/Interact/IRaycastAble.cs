using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace LostSouls.Interact
{
    public interface IRaycastAble 
    {
        bool HandleRaycast(Interact callingInteract);
    }
}
