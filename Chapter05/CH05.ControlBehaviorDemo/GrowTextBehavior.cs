using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace CH05.ControlBehaviorDemo
{
    public class GrowTextBehavior : Behavior<TextBlock>
    {
        public int GrowBySize { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseEnter -= AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave -= AssociatedObject_MouseLeave;
        }

        private void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            AssociatedObject.FontSize -= GrowBySize;
        }

        private void AssociatedObject_MouseEnter(object sender, MouseEventArgs e)
        {
            AssociatedObject.FontSize += GrowBySize;
        }
    }
}
