using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    bool BossActive = false;
    bool Attacking = false;
    int deurKeuze;
    AnimationHandler animHandler;
    Animator animator;

    [SerializeField] private GameObject BossPrefab; 

    private Transform[] deur;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        animHandler = GetComponent<AnimationHandler>();
        deur = GameObject.Find("DoorSpawnLocations").GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if(!Attacking)
        {
            transform.LookAt(player.transform.position);
        }
    }

    void Start()
    {
        StartCoroutine(startBoss());
    }

    IEnumerator startBoss()
    {
        yield return new WaitForSeconds(1);
        BossActive = true;
        StartCoroutine(Slam());
        StartCoroutine(Spin());
        StartCoroutine(Train());
    }

    IEnumerator Slam()
    {
        while (BossActive)
        {
            yield return new WaitForSeconds(2); // cd
            if (Attacking == false) 
            {
                Attacking = true;
                animHandler.setAnimation(1);
                yield return new WaitForSeconds(5); // attack animatie tijd
                Attacking = false;
            }
        }
    }

    IEnumerator Spin()
    {
        while (BossActive)
        {
            yield return new WaitForSeconds(3); // cd
            if (Attacking == false)
            {
                Attacking = true;
                animHandler.setAnimation(2);
                yield return new WaitForSeconds(5); // attack animatie tijd
                Attacking = false;
            }
        }
    }

    IEnumerator Train()
    {
        while (BossActive)
        {
            yield return new WaitForSeconds(3); // cd
            if (Attacking == false)
            {
                Attacking = true;
                animHandler.setAnimation(3);
                yield return new WaitForSeconds(7);
                deurKeuze = Random.Range(0, 5);
                switch (deurKeuze) 
                {
                    case 1:
                        GameObject obj = Instantiate(BossPrefab, deur[0].transform.position, deur[0].transform.rotation);
                        // runne deur 1 gaan gloeien
                        // dit model uit
                        break;
                    case 2:
                        GameObject obj1 = Instantiate(BossPrefab, deur[1].transform.position, deur[1].transform.rotation);
                        // spawn op deur 2
                        // runne deur 2 gaan gloeien
                        // dit model uit
                        break;
                    case 3:
                        GameObject obj2 = Instantiate(BossPrefab, deur[2].transform.position, deur[2].transform.rotation);
                        // spawn op deur 3
                        // runne deur 3 gaan gloeien
                        // dit model uit
                        break;
                    case 4:
                        GameObject obj3 = Instantiate(BossPrefab, deur[3].transform.position, deur[3].transform.rotation);
                        // spawn op deur 4
                        // runne deur 4 gaan gloeien
                        // dit model uit
                        break;
                }
            }
            yield return new WaitForSeconds(6);
            animHandler.setAnimation(5);
        }
    }

    public IEnumerator reappear()
    {
        animHandler.setAnimation(5);

        yield return new WaitForSeconds(2.5f); // boss reappear animatie tijd
        StartCoroutine(startBoss());
    }
}
