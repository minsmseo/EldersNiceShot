using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRenderingController : MonoBehaviour
{
    public Renderer objectRenderer;

    private void Start()
    {
        // ���� ������Ʈ�� �ִ� Renderer ������Ʈ ����
        //objectRenderer = GetComponent<Renderer>();
        DisableRendering();
    }

    public void DisableRendering()
    {
        // ���� ������Ʈ�� ������ ��Ȱ��ȭ
        objectRenderer.enabled = false;
    }

    public void EnableRendering()
    {
        // ���� ������Ʈ�� ������ Ȱ��ȭ
        objectRenderer.enabled = true;
    }
}