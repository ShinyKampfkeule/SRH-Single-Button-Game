using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class TubeInteractionHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject ExitTube = null;

    [SerializeField]
    private GameObject player;

    private bool inputsDisabled = false;

    public UnityEvent disableInputs;
    public UnityEvent enableInputs;

    public void PlayerInteraction()
    {
        Collider2D collider = player.GetComponent<TriggerHandler>().collidedTube;
        if (collider != null && collider.name == transform.name)
        {
            TubeAnimation();
        }
    }

    public void TubeAnimation()
    {
        if (!inputsDisabled)
        {
            disableInputs.Invoke();
            inputsDisabled = true;
        }
        Sequence sequence = DOTween.Sequence();
        sequence.Append(player.transform.DOMove(transform.position, 0).SetEase(Ease.Linear));
        if (player.name.Contains("Top"))
        {
            sequence.Append(player.transform.DOJump(transform.position, 3, 1, 1).SetEase(Ease.Linear));
            sequence.Join(player.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.Linear).SetDelay(.5f));
            sequence.Append(player.transform.DOMove(ExitTube.transform.position, 0).SetEase(Ease.Linear));
        }
        else
        {
            sequence.Append(player.transform.DOJump(transform.position, -3, 1, 1).SetEase(Ease.Linear));
            sequence.Join(player.transform.DOScale(new Vector3(0, 0, 0), .5f).SetEase(Ease.Linear).SetDelay(.5f));
            sequence.Append(player.transform.DOMove(ExitTube.transform.position, 0).SetEase(Ease.Linear));
        }
        sequence.onComplete += FlipReset;
    }

    public void FlipReset()
    {
        Sequence sequence = DOTween.Sequence();
        if (player.name.Contains("Top"))
        {
            sequence.Append(player.transform.DOJump(player.transform.position, 3, 1, 1));
            sequence.Join(player.transform.DOScale(new Vector3(1, 1, 0), .5f).SetEase(Ease.Linear));
        }
        else
        {
            sequence.Append(player.transform.DOJump(player.transform.position, -3, 1, 1));
            sequence.Join(player.transform.DOScale(new Vector3(1, 1, 0), .5f).SetEase(Ease.Linear));
        }
        sequence.onComplete += ResetSettings;
    }

    public void ResetSettings()
    {
        inputsDisabled = false;
        enableInputs.Invoke();
        player.GetComponent<TriggerHandler>().collidedTube = null;
    }
}
