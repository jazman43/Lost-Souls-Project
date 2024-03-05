using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostSouls.Saving
{
    public interface ISaveable 
    {
        object CapturState();

        void RestoreState(object state);
    }
}
