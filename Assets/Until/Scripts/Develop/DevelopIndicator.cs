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

    public abstract class DevelopIndicatorElement
    {
        public abstract string DisplayText { get; }
        public abstract int Width { get; }
        public abstract int Height { get; }
        public bool Visible { get; set; } = true;
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
        public void regist(DevelopIndicatorElement element, DevelopIndicatorAnchor anchor = DevelopIndicatorAnchor.RightTop)
        {
            var context = _ContextCollection[(int)anchor];
            context.Collection.Add(element);
        }
        #endregion

        #region Service
        /// <summary>
        /// ï`âÊ
        /// </summary>
        /// <param name="screen">âÊñ óÃàÊ</param>
        public void draw(RectInt screen)
        {
            // âEè„ÇÃï`âÊ
            drawAnchor(_ContextCollection[(int)DevelopIndicatorAnchor.RightTop], screen.x, screen.y);

            // âEâ∫ÇÃï`âÊ
            var rb_context = _ContextCollection[(int)DevelopIndicatorAnchor.RightBottom];
            var rb_size = calculateSize(rb_context);
            drawAnchor(rb_context, screen.x, screen.y + screen.height - rb_size.y);

            // ç∂è„ÇÃï`âÊ
            var lt_context = _ContextCollection[(int)DevelopIndicatorAnchor.LeftTop];
            var lt_size = calculateSize(lt_context);
            drawAnchor(lt_context, screen.x + screen.width - lt_size.x, screen.y);

            // ç∂â∫ÇÃï`âÊ
            var lb_context = _ContextCollection[(int)DevelopIndicatorAnchor.LeftBottom];
            var lb_size = calculateSize(lb_context);
            drawAnchor(lb_context, screen.x + screen.width - lb_size.x, screen.y + screen.height - lb_size.y);
        }

        /// <summary>
        /// ÉAÉìÉJÅ[Ç≤Ç∆ÇÃï`âÊ
        /// </summary>
        /// <param name="context"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void drawAnchor(Context context, int x, int y)
        {
            var rect = new Rect(x, y, 0, 0);
            foreach (var element in context.Collection)
            {
                rect.width = element.Width;
                rect.height = element.Height;
                GUI.Label(rect, element.DisplayText);
                rect.y = rect.y + rect.height;
            }
        }

        /// <summary>
        /// ÉTÉCÉYåvéZ
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private Vector2Int calculateSize(Context context)
        {
            var size = new Vector2Int();
            foreach (var element in context.Collection)
            {
                size.x = Math.Max(size.x, element.Width);
                size.y += element.Height;
            }
            return size;
        }

        #endregion

        #endregion
    }
}
