using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    private bool BossActive = false;
    private bool Attacking = false;
    private int deurKeuze;
    private AnimationHandler animHandler;
    private Animator animator;

    [SerializeField] private GameObject BossPrefab; 

    public Transform[] deur;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        animHandler = GetComponent<AnimationHandler>();
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
        //StartCoroutine(Slam());
        //StartCoroutine(Spin());
        StartCoroutine(Train());
    }

    IEnumerator Slam()
    {
        while (BossActive)
        {
            if (Attacking == false) 
            {
                Attacking = true;
                animHandler.setAnimation(1);
                //yield return new WaitForSeconds(animHandler.getAnimationClipLength()); // attack animatie tijd
                yield return new WaitForSeconds(5);  // cd
                Attacking = false;
            }
        }
    }

    IEnumerator Spin()
    {
        while (BossActive)
        {
            yield return new WaitForSeconds(5);
            // cd
            if (Attacking == false)
            {
                Attacking = true;
                animHandler.setAnimation(2);
                yield return new WaitForSeconds(animHandler.getAnimationClipLength()); // attack animatie tijd
                yield return new WaitForSeconds(6);
                Attacking = false;
            }
        }
    }

    IEnumerator Train()
    {
        while (BossActive)
        {
            yield return new WaitForSeconds(4); // cd
            if (Attacking == false)
            {
                Attacking = true;
                animHandler.setAnimation(3);
                yield return new WaitForSeconds(3);
                deurKeuze = Random.Range(0, 4);
                print(deurKeuze);

                switch (deurKeuze) 
                {
                    case 0:
                        GameObject obj = Instantiate(BossPrefab, deur[0].transform.position, deur[0].transform.rotation);
                        print(obj.transform.position);
                        // runne deur 1 gaan gloeien
                        // dit model uit
                        break;
                    case 1:
                        GameObject obj1 = Instantiate(BossPrefab, deur[1].transform.position, deur[1].transform.rotation);
                        print(obj1.transform.position);
                        // spawn op deur 2
                        // runne deur 2 gaan gloeien
                        // dit model uit
                        break;
                    case 2:
                        GameObject obj2 = Instantiate(BossPrefab, deur[2].transform.position, deur[2].transform.rotation);
                        print(obj2.transform.position);
                        // spawn op deur 3
                        // runne deur 3 gaan gloeien
                        // dit model uit
                        break;
                    case 3:
                        GameObject obj3 = Instantiate(BossPrefab, deur[3].transform.position, deur[3].transform.rotation);
                        print(obj3.transform.position);
                        // spawn op deur 4
                        // runne deur 4 gaan gloeien
                        // dit model uit
                        break;
                }
            }
            yield return new WaitForSeconds(6);
            animHandler.setAnimation(5);
            Attacking = false;
        }
    }

    public IEnumerator reappear()
    {
        yield return new WaitForSeconds(1f);
        animHandler.setAnimation(5);

        yield return new WaitForSeconds(2.5f); // boss reappear animatie tijd
        StartCoroutine(startBoss());
    }
}
