using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.combat
{
    public class WeaponDamage : MonoBehaviour
    {
        [SerializeField] private Collider playerCollider;

        private float damage;
        private List<Collider> alreadyCollidedWith = new List<Collider>();

        private void OnEnable()
        {
            alreadyCollidedWith.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == playerCollider) return;

            if (alreadyCollidedWith.Contains(other)) return;

            alreadyCollidedWith.Add(other);

            if(other.TryGetComponent<PlayerHealth>(out PlayerHealth health))
            {
                health.DealDamage(10);
            }

            if(other.TryGetComponent<Health>(out Health otherHealth))
            {
                otherHealth.DealDamage(damage);
            }
        }

        public void SetAttack(float damage)
        {
            Random.Range(damage - 3f, damage + 3f);

            this.damage = damage;
        }
    }

}