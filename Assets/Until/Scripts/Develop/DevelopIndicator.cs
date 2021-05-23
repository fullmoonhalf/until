#if TEST
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using until.system;
using until.develop;


namespace until.develop
{
    public enum DevelopIndicatorAnchor
    {
        LeftTop,
        LeftBottom,
        RightTop,
        RightBottom,
    }

    public interface DevelopIndicatorElement
    {
        public abstract string DevelopIndicatorText { get; }
        public abstract int DevelopIndicatorWidth { get; }
        public abstract int DevelopIndicatorHeight { get; }
        public abstract void onIndicatorUpdate();
    }
}


namespace until.singleton
{

    public class DevelopIndicator : Singleton<DevelopIndicator>
    {
        #region Definitions
        private class Context
        {
            public List<DevelopIndicatorElement> Collection = new List<DevelopIndicatorElement>();
        }
        #endregion

        #region Fields.
        private Context[] _ContextCollection = null;
        #endregion

        #region Methods
        #region Singleton
        public override void onSingletonAwake()
        {
            var count = Enum.GetValues(typeof(DevelopIndicatorAnchor)).Length;
            _ContextCollection = new Context[count];
            for (int index = 0; index < count; ++index)
            {
                _ContextCollection[index] = new Context();
            }
        }

        public override void onSingletonStart()
        {
        }

        public override void onSingletonDestroy()
        {
            _ContextCollection = null;
        }
        #endregion

        #region Requests
        /// <summary>
        /// �������ēo�^����
        /// </summary>
        /// <typeparam name="T">�o�^�������C���W�P�[�^�[</typeparam>
        /// <param name="anchor"></param>
        public void create<T>(DevelopIndicatorAnchor anchor = DevelopIndicatorAnchor.LeftTop)
            where T : DevelopIndicatorElement, new()
        {
            regist(new T(), anchor);
        }

        /// <summary>
        /// �������ꂽ�I�u�W�F�N�g��o�^����
        /// </summary>
        /// <param name="element">�o�^�������C���W�P�[�^�[</param>
        /// <param name="anchor"></param>
        public void regist(DevelopIndicatorElement element, DevelopIndicatorAnchor anchor = DevelopIndicatorAnchor.LeftTop)
        {
            var context = _ContextCollection[(int)anchor];
            context.Collection.Add(element);
        }
        #endregion

        #region Service
        public void update()
        {
            foreach (var context in _ContextCollection)
            {
                foreach (var element in context.Collection)
                {
                    element.onIndicatorUpdate();
                }
            }
        }

        /// <summary>
        /// �`��
        /// </summary>
        /// <param name="screen">��ʗ̈�</param>
        public void draw(RectInt screen)
        {
            // ����̕`��
            drawAnchor(_ContextCollection[(int)DevelopIndicatorAnchor.LeftTop], screen.x, screen.y);

            // �����̕`��
            var lb_context = _ContextCollection[(int)DevelopIndicatorAnchor.LeftBottom];
            var lb_size = calculateSize(lb_context);
            drawAnchor(lb_context, screen.x, screen.y + screen.height - lb_size.y);

            // �E��̕`��
            var rt_context = _ContextCollection[(int)DevelopIndicatorAnchor.RightTop];
            var rt_size = calculateSize(rt_context);
            drawAnchor(rt_context, screen.x + screen.width - rt_size.x, screen.y);

            // �E���̕`��
            var rb_context = _ContextCollection[(int)DevelopIndicatorAnchor.RightBottom];
            var rb_size = calculateSize(rb_context);
            drawAnchor(rb_context, screen.x + screen.width - rb_size.x, screen.y + screen.height - rb_size.y);
        }

        /// <summary>
        /// �A���J�[���Ƃ̕`��
        /// </summary>
        /// <param name="context"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void drawAnchor(Context context, int x, int y)
        {
            var rect = new Rect(x, y, 0, 0);
            foreach (var element in context.Collection)
            {
                rect.width = element.DevelopIndicatorWidth;
                rect.height = element.DevelopIndicatorHeight;
                GUI.Label(rect, element.DevelopIndicatorText);
                rect.y = rect.y + rect.height;
            }
        }

        /// <summary>
        /// �T�C�Y�v�Z
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private Vector2Int calculateSize(Context context)
        {
            var size = new Vector2Int();
            foreach (var element in context.Collection)
            {
                size.x = Math.Max(size.x, element.DevelopIndicatorWidth);
                size.y += element.DevelopIndicatorHeight;
            }
            return size;
        }

        #endregion

        #endregion
    }
}
#endif
