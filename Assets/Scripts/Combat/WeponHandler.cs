using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.combat
{
    public class WeponHandler : MonoBehaviour
    {
        [SerializeField] private GameObject[] weapons;

        public void EnableWeapon(int weaponIndex)
        {
            weapons[weaponIndex].SetActive(true);
        }

        public void DisableWeapon(int weaponIndex)
        {
            weapons[weaponIndex].SetActive(false);
        }
    }
}
