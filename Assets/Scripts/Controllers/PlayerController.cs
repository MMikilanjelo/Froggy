using System.Collections;
using System.Collections.Generic;
using Entities;
using Managers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IList<Hero> heroes_ = new List<Hero>();
    EventBinding<HeroSpawnedEvent> heroSpawnedEventBinding;
    public IEnumerator GameLoopEnumerator { get; private set; }
    private void OnEnable()
    {
        heroSpawnedEventBinding = new EventBinding<HeroSpawnedEvent>(OnHeroSpawned);
        EventBus<HeroSpawnedEvent>.Register(heroSpawnedEventBinding);

    }
    private void OnDisable()
    {
        EventBus<HeroSpawnedEvent>.Deregister(heroSpawnedEventBinding);
        StopAllCoroutines();
    }
    private void Start()
    {
        GameLoopEnumerator = GameLoop();
    }
    public void PerformTurn()
    {
        StartCoroutine(GameLoopEnumerator);
    }
    private IEnumerator GameLoop()
    {
        while (true)
        {
            Debug.Log("players turn");
            yield return null;
        }
    }
    private void OnHeroSpawned(HeroSpawnedEvent heroSpawnedEvent)
    {
        heroes_.Add(heroSpawnedEvent.heroInstance);
    }
    private bool CheckPlayerTurn()
    {
        return GameManager.Instance.GameState == GameState.PlayerTurn ? true : false;
    }
}
