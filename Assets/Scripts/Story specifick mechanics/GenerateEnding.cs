using System;
using UnityEngine;

    public class GenerateEnding : MonoBehaviour
    {
        [SerializeField] private GameObject[] endingZone = new GameObject[4];
        [SerializeField] private QuestManager qm;
        [SerializeField] private GameObject Haron;
        [SerializeField] private GameObject Kahir;
        [SerializeField] private GameObject pos1;
        [SerializeField] private GameObject pos2;
        [SerializeField] private BoxCollider haronColl;
        [SerializeField] private BoxCollider kahirColl;

        private void OnTriggerEnter(Collider other)
        {
            Haron.transform.position = pos1.transform.position;
            Haron.transform.rotation = pos1.transform.rotation;
            Kahir.transform.position = pos2.transform.position;
            Kahir.transform.rotation = pos2.transform.rotation;
            haronColl.enabled = false;
            kahirColl.enabled = false;
            
            if (qm.hasBomb && qm.killedHabitant)
            {
                endingZone[0].SetActive(true);
            }
            else if (!qm.hasBomb && qm.killedHabitant)
            {
                endingZone[1].SetActive(true);
            }
            else if (!qm.hasBomb && !qm.killedHabitant)
            {
                endingZone[2].SetActive(true);
            }
            else if (qm.hasBomb && !qm.killedHabitant)
            {
                endingZone[3].SetActive(true);
            }
        }
        
    }
