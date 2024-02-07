using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class SetEnemyTarget : MonoBehaviour
{
    [SerializeField] private Pathfinding.AIDestinationSetter aIDestinationSetter;
    private GameObject target;

    public Animator anim;
  
    private void Start()
    {
        enemyTargetsPlayer();
    }

    private void Update()
    {
      anim.SetBool("moving", true);
    }

    public void enemyTargetsPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        aIDestinationSetter.target = target.transform;
    }
}
