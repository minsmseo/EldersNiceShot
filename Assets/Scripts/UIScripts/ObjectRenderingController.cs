using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRenderingController : MonoBehaviour
{
    public Renderer objectRenderer;

    private void Start()
    {
        // 게임 오브젝트에 있는 Renderer 컴포넌트 참조
        //objectRenderer = GetComponent<Renderer>();
        DisableRendering();
    }

    public void DisableRendering()
    {
        // 게임 오브젝트의 렌더링 비활성화
        objectRenderer.enabled = false;
    }

    public void EnableRendering()
    {
        // 게임 오브젝트의 렌더링 활성화
        objectRenderer.enabled = true;
    }
}