using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public Collider2D[] listBoss;
    private float hpMax;
	private UbhShotCtrl[] Ubh ;
	private PlaneDie[] planeDie;
    private float savePos;
    [HideInInspector]
    public bool startBoss;

	// Use this for initialization
	void Start () {
		Ubh = new UbhShotCtrl[listBoss.Length];
		planeDie = new PlaneDie[listBoss.Length];
        savePos = transform.position.x;
		for (int i = 0; i < listBoss.Length; i++) {
			Ubh [i] = listBoss [i].GetComponent<UbhShotCtrl> ();
			planeDie [i] = listBoss [i].GetComponent<PlaneDie> ();
		};


    }

    public void setupBoss(float hp,bool startBoss)
    {
        this.hpMax = hp;
        this.startBoss = startBoss;
		resetColider ();
        Debug.Log(hp + "");
    }

    public void updateHpBoss(float hp)
    {
        if (startBoss)
        {
            if (hp >= hpMax * 2 / 3)
            {
                activeBoss(0);
            }

            if (hp < hpMax * 2 / 3 && hp >= hpMax / 3)
            {
                activeBoss(1);
            }

            if (hp < hpMax / 3)
            {
                activeBoss(2);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector2(savePos + Mathf.Sin(Time.time), transform.position.y);

    }
	void resetColider(){
		for (int i = 0; i < listBoss.Length; i++) {
			listBoss [i].enabled = true;
			listBoss [i].isTrigger = false;
		}

	}

    void activeBoss(int index)
    {
		int startTime, endTime;
		startTime = System.DateTime.Now.Millisecond;
        for (int i = 0; i < listBoss.Length; i++)
        {
            if (index == i)
            {
				if (listBoss[i].isTrigger != true)
                {
					listBoss[i].isTrigger = true;
					Ubh[i].enabled = true;
					Ubh[i].enabled = true;
					Ubh [i].StartShotRoutine();
                }
            }
            else
            {
				if (listBoss[i].isTrigger != false)
                {

//					listBoss[i].GetComponent<PlaneDie>().Explosion();
					planeDie[i].Explosion();
					listBoss[i].isTrigger = false;
					Ubh[i].StopShotRoutine();
					Ubh[i].enabled = false;
                }
            }
        }
		endTime = System.DateTime.Now.Millisecond - startTime;
		Debug.Log ("Time cost: " + endTime + " ms");
    }
}
