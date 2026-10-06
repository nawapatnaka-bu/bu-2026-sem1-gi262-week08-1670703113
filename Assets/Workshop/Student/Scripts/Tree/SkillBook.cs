using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


    public class SkillBook : MonoBehaviour
    {
        public SkillTree attackSkillTree;

        Skill attack;
        Skill fireStorm;
        Skill fireBall;
        Skill fireBlast;
        Skill fireWave;
        Skill fireExplosion;

        public void Start()
        {
        // build skill tree
        // └── Attack
        //     └── FireStorm
        //         ├── FireBlast
        //         └── FireBall
        //             └── FireWave
        //                 └── FireExplosion

        // 1. set the nextSkills for each skill

        // [0] Attack -> FireStorm
        attack = new Skill("Attack");
        fireStorm = new Skill("FireStorm");
        fireBall = new Skill("FireBall");
        fireBlast = new Skill("FireBlast");
        fireWave = new Skill("fireWave");
        fireExplosion = new Skill("FireExplosion");

        attack.nextSkills.Add(fireStorm);
        fireStorm.nextSkills.Add(fireBall);
        fireStorm.nextSkills.Add(fireBall);
        fireBall.nextSkills.Add(fireBlast);
        fireWave.nextSkills.Add(fireExplosion);

        // [1] FireStorm -> FireBlast

        // [2] FireStorm -> FireBall

        // [3] FireBall -> FireWave

        // [4] FireWave -> FireExplosion

        // [5] Attack -> FireStorm

        this.attackSkillTree = new SkillTree(attack);
        attack.isAvailable = true;
        }

        public void Update()
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard != null && keyboard.pKey.wasPressedThisFrame)
            {
                attackSkillTree.rootSkill.PrintSkillTreeHierarchy("");
                // attackSkillTree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
            } 
        }
    }

