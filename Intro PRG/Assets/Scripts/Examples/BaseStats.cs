using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Stats
{

    public class BaseStats : MonoBehaviour
    {
        #region Structs
        [System.Serializable]
        public struct StatBlock
        {
            public int name;
            public int value;

        }

        [System.Serializable]
        public struct LifeForceStatus
        {
            public string name;
            public float currentValue;
            public float maxValue;
            public float regenValue;
            public Image displayImage;
        }


        #endregion
        #region Variables
        [Header("Character Data")]
        public new string name;
       

        public StatBlock[] characterstats = new StatBlock[6];
        public LifeForceStatus[] characterStatus = new
            LifeForceStatus[3];


        [Header("Character Level Info")]
        public int level = 0;
        public float currentExp, neededExp, maxExp;
   

        [Header("Death")]
        public Image damageImage;
        public Image deathImage;
        public Text deathText;
        public AudioClip deathClip;
        public AudioSource playersAudio;
        public Transform checkPoint;
        public PlayerSaveAndLoad saveAndLoad;

        public float flashspeed = 5;
        public Color flashColour = new Color(1, 0, 0, 0.2f);
        public static bool isDead;

        //REMOVE LATER
        public bool damaged;
        public bool canHeal;
        public float healTimer;

        

        #endregion
        #region death and respawn with a little bit of healing too
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                damaged = true;
                characterStatus[0].currentValue -= 25;
            }
            


            for (int i = 0; i < characterStatus.Length; i++)
            {
                characterStatus[i].displayImage.fillAmount = Mathf.Clamp01(characterStatus[i].currentValue / characterStatus[i].maxValue);
            }

            #region damage flash
            if(damaged && !isDead)
            {
                damageImage.color = flashColour;
                damaged = false;
            }
            else if(damageImage.color.a > 0)
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashspeed * Time.deltaTime);
            }


            #endregion
            if(!canHeal)
            {
                healTimer += Time.deltaTime;
                if(healTimer >= 5)
                {
                    canHeal = true;
                }
            }

        }

        private void LateUpdate()
        {
            if (characterStatus[0].currentValue <= 0 && !isDead )
            {
                Death();

            }
            if (canHeal && characterStatus[0].currentValue < characterStatus[0].maxValue && characterStatus[0].currentValue > 0)
            {
                HealOverTime();
            }
        }

        void Death()
        {
            //Set the death flag to dead and clear existing Text if text isnt blank
            isDead = true;
            deathText.text = "";
            //Set the audio to play our death clip
            playersAudio.clip = deathClip;
            playersAudio.Play();
            //Trigger the animation
            deathImage.GetComponent<Animator>
                ().SetTrigger("isDead");
            //2 - death text
            Invoke("DeathText", 2f);
            //6 - revive text
            Invoke("ReviveText", 6f);
            //9 - respawn function
            Invoke("Revive", 9f);

        }
        void DeathText()
        {
            deathText.text = "Nice one dummy, you ded";
        }
        void ReviveText()
        {
            deathText.text = "...But the Gods have decided to yeet you back to life...";


        }
        void Revive()
        {
            //Reset all the things
            deathText.text = "";
            isDead = false;
            characterStatus[0].currentValue = characterStatus[0].maxValue;

            //load position
            this.transform.position = checkPoint.position;
            this.transform.rotation = checkPoint.rotation;
            //Revive
            deathImage.GetComponent<Animator>().SetTrigger("Revive");
        }
        #endregion

        public void DamagePlayer(float damage)
        {
            damaged = true;
            characterStatus[0].currentValue -= damage;
            //unable to heal
            canHeal = false;
            healTimer = 0;


        }

        public void HealOverTime()
        {
            characterStatus[0].currentValue += Time.deltaTime * (characterStatus[0].regenValue/*maybe multiply by con?*/);

        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("CheckPoint"))
            {
                checkPoint = other.transform;

                //Increase Healing
                characterStatus[0].regenValue += 4;
                //Save
                saveAndLoad.Save();
            }
           
        }

        private void OnTriggerExit(Collider other)
        {if (other.gameObject.tag == "CheckPoint")
            {

                //Go back to normal healing
                characterStatus[0].regenValue -= 4;
            }
        }
    }


   

}

