using UIKit;

namespace FormsControls.Touch
{
	public class GestureRecognizerDelegate : UIGestureRecognizerDelegate
	{
		public override bool ShouldBegin(UIGestureRecognizer recognizer)
		{
			return recognizer.LocationInView(recognizer.View).X <= 44;
		}
	}
}