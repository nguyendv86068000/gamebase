using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimSimple
{
    public static Sequence UpDown(GameObject model, float distance, float time)
    {
        float y = model.transform.localPosition.y;
        var up = model.transform.DOLocalMoveY(y + distance, time);
        var dowm = model.transform.DOLocalMoveY(y, time);
        return DOTween.Sequence()
            .Append(up)
            .Append(dowm)
            .OnComplete(() => { UpDown(model, distance, time); });
    }
    public static Sequence Zoomer(GameObject model, float zoom, float time)
    {
        var big = model.transform.DOScale(zoom, time);
        var small = model.transform.DOScale(1, time);
        return DOTween.Sequence()
            .Append(big)
            .Append(small)
            .OnComplete(() => { Zoomer(model, zoom, time); });
    }
}
