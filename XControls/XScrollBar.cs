using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace XControls
{
    public partial class XScrollBar : Control
    {
        private int minimum = 0;
        private int maximum = 100;
        private int largeChange = 50;
        private int smallChange = 1;
        private int scrollValue = 0;
        private Rectangle ScrollBannerRectangle;
        private int bannerWidth;
        private double bl;
        private int MaxValue = 51;

        [Category("自定义事件")]
        [Description("用户滚动滑块时触发此事件")]
        [Browsable(true)]
        public event EventHandler<ScrollEventArgs> Scroll;

        [Category("自定义事件")]
        [Description("滚动条滑块的值改变时触发此事件")]
        [Browsable(true)]
        public event EventHandler ValueChanged;


        [Category("自定义事件")]
        [Description("鼠标点击滑动时触发")]
        [Browsable(true)]
        public event EventHandler MouseDownBanner;

        [Category("自定义事件")]
        [Description("鼠标松开滑动时触发")]
        [Browsable(true)]
        public event EventHandler MouseUpBanner;

        public class ScrollEventArgs : EventArgs
        {
            public int NewValue = 0;
            public int OldValue = 0;
        }


        bool mouseHover = false;

        //D2d d2D;
        public XScrollBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
            CalcScrollBannerRectangle(true);
        }
        ~XScrollBar()
        {
            //  d2D?.Dispose();
        }

        [Browsable(true)]
        public int Minimum
        {
            get => minimum;
            set
            {
                if (minimum == value)
                    return;
                minimum = value;
                CalcScrollBannerRectangle(true);
                Invalidate();
            }
        }

        [Browsable(true)]
        public int Maximum
        {
            get => maximum;
            set
            {
                if (maximum == value)
                    return;
                maximum = value;
                CalcScrollBannerRectangle(true);
                Invalidate();
            }
        }

        [Browsable(true)]
        public int LargeChange
        {
            get => largeChange;
            set
            {
                largeChange = value;
                CalcScrollBannerRectangle(true);
                Invalidate();
            }
        }

        [Browsable(true)]
        public int SmallChange
        {
            get => smallChange;
            set
            {
                if (smallChange == value)
                    return;
                smallChange = value;
                CalcScrollBannerRectangle(true);
                Invalidate();
                //DoPaint();
            }
        }

        [Browsable(true)]
        public int Value
        {
            get => scrollValue;
            set
            {
                if (value < Minimum)
                    value = Minimum;
                else if (value > MaxValue)
                    value = MaxValue;
                if (scrollValue == value)
                    return;

                this.scrollValue = value;
                scrollTop = (int)(value * bl);
                CalcScrollBannerRectangle();
                Invalidate();
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CalcScrollBannerRectangle(true);
        }

        protected void CalcScrollBannerRectangle()
        {
            CalcScrollBannerRectangle(false);
        }

        protected void CalcScrollBannerRectangle(bool calcScrollTop)
        {
            MaxValue = Maximum - LargeChange + 1 + Minimum;

            bl = (Height - Padding.Top - Padding.Bottom) / (double)(Maximum - Minimum + 1);
            int bannerHeight = (int)(LargeChange * bl);
            bannerWidth = Width - 2;
            if (calcScrollTop)
                scrollTop = Convert.ToInt32(Value * bl);
            ScrollBannerRectangle = new Rectangle(0,
                Padding.Top + scrollTop,
                bannerWidth, bannerHeight);
        }

        protected MouseButtons mouseButtonsState = 0;
        protected bool mouseDownOnBanner = false;
        protected bool IsMouseDown = false;
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                if (mouseDownOnBanner)
                {
                    mouseDownOnBanner = false;
                    MouseUpBanner?.Invoke(this, EventArgs.Empty);
                }
                IsMouseDown = false;
                Invalidate();
            }

        }

        Point mouseDownPoint = new Point(0, 0);
        int oldValue = 0;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (mouseHover)
            {
                mouseHover = false;
                Invalidate();
            }
        }

        protected void ScrollEvent(int oldValue, int newValue)
        {
            Scroll?.Invoke(this, new ScrollEventArgs { OldValue = oldValue, NewValue = newValue });
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                /*
                 * 如果当前鼠标左键点击的区域不在滚动条内
                 * 则将滚动条（中心点）滚动至鼠标点击位置
                 */
                if (!ScrollBannerRectangle.Contains(e.X, e.Y))
                {
                    int top = e.Y - (ScrollBannerRectangle.Height / 2) - Padding.Top;
                    if (top < 0)
                        top = 0;
                    else if (top > Height - Padding.Top - ScrollBannerRectangle.Height)
                        top = Height - Padding.Top - ScrollBannerRectangle.Height;

                    int newValue = Convert.ToInt32(top / bl);
                    ScrollEvent(scrollValue, newValue);
                    Value = newValue;
                }
                mouseDownPoint.X = e.X;
                mouseDownPoint.Y = e.Y;
                oldValue = scrollTop;

                IsMouseDown = true;
                mouseDownOnBanner = true;
                MouseDownBanner?.Invoke(this, EventArgs.Empty);
            }
            Invalidate();
        }
        int scrollTop = 0;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            bool hitTest = ScrollBannerRectangle.Contains(e.X, e.Y);

            if (mouseDownOnBanner)
            {
                scrollTop = oldValue + e.Y - mouseDownPoint.Y;
                int v;
                if (scrollTop < 0)
                {
                    v = 0;
                    scrollTop = 0;
                }
                else if (scrollTop > MaxValue * bl)
                {
                    v = MaxValue;
                    scrollTop = Convert.ToInt32(MaxValue * bl);
                }
                else
                {
                    v = Convert.ToInt32(scrollTop / bl);
                }

                if (scrollValue != v)
                {
                    // Console.WriteLine(v);
                    Scroll?.Invoke(this, new ScrollEventArgs { OldValue = scrollValue, NewValue = v });
                    scrollValue = v;
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
                CalcScrollBannerRectangle();
                Invalidate();
                //Update用于立刻更新界面，否则有可能造成闪烁
                Update();
            }
            else if (!mouseHover && hitTest)
            {
                mouseHover = true;
                Invalidate();
            }
            else if (mouseHover && !hitTest)
            {
                mouseHover = false;
                Invalidate();
            }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            return;
        }
        protected void OnPaintBackground(Graphics graphics)
        {
            graphics.Clear(Parent.BackColor);
        }
        protected virtual void OnPaintScrollBanner(Graphics graphics)
        {

            if (!Enabled)
                return;

            Color bannerColor;

            if (IsMouseDown)
            {
                bannerColor = Color.FromArgb(223, 74, 22);
            }
            else if (mouseHover)
            {
                bannerColor = Color.FromArgb(192, 192, 192);
            }
            else
            {
                bannerColor = Color.FromArgb(255, 255, 255);
            }

            using (SolidBrush solidBrush = new SolidBrush(bannerColor))
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.StartFigure();
                graphicsPath.AddArc(
                    ScrollBannerRectangle.Left,
                    ScrollBannerRectangle.Top,
                    ScrollBannerRectangle.Width,
                    ScrollBannerRectangle.Width,
                    180, 180);
                graphicsPath.AddLine(ScrollBannerRectangle.Right,
                    ScrollBannerRectangle.Top + ScrollBannerRectangle.Width / 2,
                    ScrollBannerRectangle.Right,
                    ScrollBannerRectangle.Bottom - ScrollBannerRectangle.Width / 2
                    );
                graphicsPath.AddArc(
                   ScrollBannerRectangle.Left,
                   ScrollBannerRectangle.Bottom - ScrollBannerRectangle.Width,
                   ScrollBannerRectangle.Width,
                   ScrollBannerRectangle.Width,
                   0, 180);
                graphicsPath.AddLine(ScrollBannerRectangle.Left,
                  ScrollBannerRectangle.Top + ScrollBannerRectangle.Width / 2,
                  ScrollBannerRectangle.Left,
                  ScrollBannerRectangle.Bottom - ScrollBannerRectangle.Width / 2
                  );
                graphicsPath.CloseFigure();
                graphics.FillPath(solidBrush, graphicsPath);
            }
            /// */
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            OnPaintBackground(pe.Graphics);
            OnPaintScrollBanner(pe.Graphics);
        }
    }
}
