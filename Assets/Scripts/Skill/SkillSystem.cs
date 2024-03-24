using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LostSouls.combat;
using LostSouls.Saving;
using System.Linq;




namespace LostSouls.skill
{
    public class SkillSystem : MonoBehaviour, ISaveable
    {
        [System.Serializable]
        public class SkillButtonPair
        {
            public string skillName;
            public Button button;
        }
        [SerializeField] private List<SkillButtonPair> skillButtons;
        private Dictionary<string, ISkill> skills = new Dictionary<string, ISkill>();

        [SerializeField] private SoulCollictor ponits;

        private void Awake()
        {
            // Find all skills on the player GameObject and add them to the skills dictionary.
            foreach (var skill in GetComponents<ISkill>())
            {
                skills[skill.Name] = skill;
            }
        }

        private void Start()
        {
            foreach (var pair in skillButtons)
            {
                if (skills.TryGetValue(pair.skillName, out var skill))
                {
                    
                    if (skill.isUnlocked)
                    {
                        pair.button.interactable = false;
                    }
                }
            }
        }

        public void UnlockSkill(string skillName)
        {
            if(ponits.GetPonits() == 1)
            {
                if (skills.TryGetValue(skillName, out var skill))
                {
                    skill.isUnlocked = true;
                    skill.ApplySkill(gameObject);
                    ponits.SetPonits(ponits.GetPonits() - 1);
                }
            }
            else
            {
                //not enoght ponits to unlock
            }            
            
        }

        public object CaptureState()
        {
            Dictionary<string, bool> skillStates = new Dictionary<string, bool>();
            foreach (var skill in skills)
            {
                skillStates.Add(skill.Key, skill.Value.isUnlocked);
            }
            return skillStates;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, bool> skillStates = (Dictionary<string, bool>)state;
            foreach (var skillState in skillStates)
            {
                if (skills.TryGetValue(skillState.Key, out var skill))
                {
                    skill.isUnlocked = skillState.Value;
                   
                    if (skill.isUnlocked)
                    {
                        skill.ApplySkill(gameObject);
                    }
                }
            }
        }

    }
}

