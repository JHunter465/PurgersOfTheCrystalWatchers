using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace POTCW
{
    [System.Serializable]
    public class PuzzleElement
    {
        public int ID;
        public GameObject Barrier;
        public List<MinionCollectContainer> MinionCollectContainers = new List<MinionCollectContainer>();
    }

    [System.Serializable]
    public class MinionCollectContainer
    {
        public int MinionsNeeded = 3;
        public MinionType MinionType;
        public int Collected = 0;
        public bool Completed = false;
    }

    public class BossModeSwitchManager : MonoBehaviour
    {
        public List<PuzzleElement> BossModeSwitchSides = new List<PuzzleElement>();

        private int countedCompletedPuzzles = 0;

        private void Start()
        {
            foreach (var cntr in BossModeSwitchSides)
            {
                cntr.Barrier.SetActive(false);
            }
            EventManager<Dictionary<int, MinionType>>.AddHandler(EVENT.CollectMinions, CollectMinion);
        }

        public void CollectMinion(Dictionary<int, MinionType> incoming)
        {
            Debug.Log("Inside collect minion event");
            //Fist reset al barriers so we are sure the player is not able to change the boss mode


            PuzzleElement container = null;
            MinionCollectContainer minionCollectContainer = null;

            foreach(KeyValuePair<int, MinionType> keyValuePair in incoming)
            {

                container = BossModeSwitchSides?.Find(bmss => bmss.ID == keyValuePair.Key);
                minionCollectContainer = container.MinionCollectContainers?.Find(mcc => mcc.MinionType == keyValuePair.Value);
            }

            if (container == null) return;
            if (minionCollectContainer == null) return;

            //Debug.Log("CollectMinion: " + minionCollectContainer.MinionType + "we have: "+ minioncoll);

            //Using list container
            minionCollectContainer.Collected++;
            if(minionCollectContainer.MinionsNeeded == minionCollectContainer.Collected)
            {
                //Unlock this minionType puzzle element
                minionCollectContainer.Completed = true;
                countedCompletedPuzzles++;
            }
            
            if(countedCompletedPuzzles >= 3)
            {
                container.Barrier.SetActive(true);
            }
        }
    }
}