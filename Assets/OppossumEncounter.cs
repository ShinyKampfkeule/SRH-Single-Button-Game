using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OppossumEncounter : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject movementGoal;

    [SerializeField]
    private GameObject tubeExit;

    [SerializeField]
    private GameObject tubeStart;

    [SerializeField]
    private GameObject cutsceneTube;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource runningSounds;

    [SerializeField]
    private InputHandler inputHandler;

    [SerializeField]
    private TimeHandler timeHandler;

    private bool inputsDisabled = false;
    private bool fleed = false;

    public UnityEvent disableInputs;
    public UnityEvent enableInputs;

    public void TubeTutorial()
    {
        Collider2D collider = player.GetComponent<TriggerHandler>().collidedNPC;
        if (collider != null && collider.name == transform.name && !fleed)
        {
            if (!inputsDisabled)
            {
                disableInputs.Invoke();
                inputsDisabled = true;
            }
            fleed = true;
            GetComponent<SpriteRenderer>().flipX = true;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMove(tubeStart.transform.position, 2).SetEase(Ease.Linear));
            sequence.Append(transform.DOJump(tubeStart.transform.position, 3, 1, 1).SetEase(Ease.Linear));
            sequence.Join(transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.Linear).SetDelay(.5f));
            sequence.Append(transform.DOMove(tubeExit.transform.position + new Vector3(0, -1.5f, 0), 0).SetEase(Ease.Linear));
            sequence.onComplete += FlipReset;
        }
    }

    public void FlipReset()
    {
        GetComponent<SpriteRenderer>().flipX = false;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOJump(transform.position, 1, 1, 1));
        sequence.Join(transform.DOScale(new Vector3(1, 1, 0), .5f).SetEase(Ease.Linear));
        sequence.Append(transform.DOMove(transform.position - new Vector3(2, 0, 0), 1).SetEase(Ease.Linear));
        sequence.Append(transform.DOMove(transform.position - new Vector3(50, 0, 0), 2.5f).SetEase(Ease.Linear));
        sequence.onComplete += ResetSettings;
    }

    public void ResetSettings()
    {
        inputsDisabled = false;
        enableInputs.Invoke();
        player.GetComponent<TriggerHandler>().collidedNPC = null;
        fleed = false;
    }

    public void Ending()
    {
        if (!fleed)
        {
            Debug.Log("Started");
            if (!inputsDisabled)
            {
                disableInputs.Invoke();
                inputsDisabled = true;
            }
            fleed = true;
            player.GetComponent<PlayerMovementHandler>().inCutscene = true;
            Sequence sequence = DOTween.Sequence();
            animator.SetFloat("Speed", 5f);
            runningSounds.Play();
            Debug.Log(runningSounds.volume);
            sequence.Append(player.transform.DOMove(player.transform.position + new Vector3(10, 0, 0), 5f).SetEase(Ease.Linear));
            sequence.onComplete += AppearingOppossum;
        }
    }

    public void AppearingOppossum()
    {
        runningSounds.Stop();
        animator.SetFloat("Speed", 0f);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(cutsceneTube.transform.position - new Vector3(0, 1.5f, 0), 0).SetEase(Ease.Linear));
        sequence.Join(transform.DOScale(new Vector3(0, 0, 0), 0).SetEase(Ease.Linear));
        sequence.Append(transform.DOJump(cutsceneTube.transform.position - new Vector3(0, .75f, 0), 3, 1, 1).SetEase(Ease.Linear));
        sequence.Join(transform.DOScale(new Vector3(1, 1, 0), .5f).SetEase(Ease.Linear));
        sequence.Append(transform.DOMove(cutsceneTube.transform.position - new Vector3(0, .75f, 0), 1).SetEase(Ease.Linear));
        sequence.onComplete += ReactingOppossumPart1;
    }

    public void ReactingOppossumPart1()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.position, 1).SetEase(Ease.Linear));
        sequence.onComplete += ReactingOppossumPart2;
    }

    public void ReactingOppossumPart2()
    {
        GetComponent<SpriteRenderer>().flipX = false;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.position - new Vector3(28, 0, 0), .5f).SetEase(Ease.Linear).SetDelay(1f));
        sequence.Append(transform.DOMove(transform.position - new Vector3(28, 0, 0), 1).SetEase(Ease.Linear));
        sequence.onComplete += ReactingOppossumPart3;
    }

    public void ReactingOppossumPart3()
    {
        player.GetComponent<SpriteRenderer>().flipX = true;
        GetComponent<SpriteRenderer>().flipX = true;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.position + new Vector3(22, 0, 0), .5f).SetEase(Ease.Linear).SetDelay(1f));
        sequence.onComplete += ReactingOppossumPart4;
    }

    public void ReactingOppossumPart4()
    {
        inputHandler.timerStart = false;
        SceneManager.LoadScene(3);
        player.GetComponent<PlayerMovementHandler>().inCutscene = false;
    }
}
