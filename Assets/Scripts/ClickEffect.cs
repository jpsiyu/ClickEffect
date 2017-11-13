using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private const float SCALE_DURATION = 0.1f;
    private Image clickImg;
    private Sprite source;

    public bool isScale = true;
    public float scaleValue = 1.5f;
    public Sprite target;

    private void Awake() {
        clickImg = transform.GetComponent<Image>();
        source = clickImg.sprite;
    }

    private void DoScaleAnim(bool isScale) {
        this.isScale = isScale;
    }

    public void SetTargetSprite(Sprite target) {
        this.target = target;
    }

    public void SetSourceSprite(Sprite source) {
        this.source = source;
    }

    public void OnPointerDown(PointerEventData eventData) {
        ZoomIn();
    }

    public void OnPointerUp(PointerEventData eventData) {
        ZoomOut();
    }

    private void ZoomIn() {
        if(isScale)
            transform.DOScale(scaleValue, SCALE_DURATION);
        if (target != null)
            clickImg.sprite = target;
    }

    private void ZoomOut() {
        transform.DOScale(1.0f, SCALE_DURATION);
        clickImg.sprite = source;
    }
}
