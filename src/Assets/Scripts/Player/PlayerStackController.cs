using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    public static PlayerStackController instance;

    public List<GameObject> blockList = new List<GameObject>();
    
    private GameObject lastBlockObject;
    public GameObject yourTrailRendererPrefab;
    [SerializeField] public GameObject floatingTextPrefab;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateLastBlockObject();
        UpdateTrailRenderers();
    }

    public void IncreaseBlockStack(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x, lastBlockObject.transform.position.y - 2f, lastBlockObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);
        UpdateLastBlockObject();
        UpdateTrailRenderers();
        ScoreManager.instance.IncreaseScore(2);
        // PlayerMovementController.instance.playerAnimator.SetBool("isJumping", true);
        StartCoroutine(DelayJumpAnimation());

        if (floatingTextPrefab) {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = "+1";
            Destroy(prefab, 1f);
        }
    }

    public void DecreaseBlock(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        blockList.Remove(_gameObject);
        UpdateLastBlockObject();
        UpdateTrailRenderers();
    }

    private void UpdateLastBlockObject()
    {
        lastBlockObject = blockList[blockList.Count - 1];
    }

    private void UpdateTrailRenderers()
    {
        for (int i = 0; i < blockList.Count; i++)
        {
            GameObject block = blockList[i];
            TrailRenderer trailRenderer = block.GetComponentInChildren<TrailRenderer>();

            if (trailRenderer == null)
            {
                GameObject trail = Instantiate(yourTrailRendererPrefab, block.transform.position - new Vector3(0, .7f, 0) , Quaternion.identity);
                trail.transform.SetParent(block.transform);
                trailRenderer = trail.GetComponent<TrailRenderer>();
            }

            trailRenderer.emitting = (i == blockList.Count - 1);
        }
    }

    IEnumerator DelayJumpAnimation()
    {
        PlayerMovementController.instance.playerAnimator.SetBool("isJumping", true);
        yield return new WaitForSeconds(1.1f);
        PlayerMovementController.instance.playerAnimator.SetBool("isMoving", true);
        PlayerMovementController.instance.playerAnimator.SetBool("isJumping", false);
    }
}