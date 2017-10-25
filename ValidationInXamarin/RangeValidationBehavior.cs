using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
namespace ValidationInXamarin
{
	public class RangeValidationBehavior : Behavior<Entry>
	{

		const string RangeRegex = @"^(3[5-9]|[4-9][0-9]|[12][0-9]{2}|3[0-4][0-9]|350)$";
		protected override void OnAttachedTo(Entry bindable)
		{
			base.OnAttachedTo(bindable);
			bindable.TextChanged += RangeValidation_TextChanged;
		}
		protected override void OnDetachingFrom(Entry bindable)
		{
			base.OnDetachingFrom(bindable);
			bindable.TextChanged -= RangeValidation_TextChanged;
		}

		private void RangeValidation_TextChanged(object sender, TextChangedEventArgs e)
		{
			bool isNoVailid;
			isNoVailid = (Regex.IsMatch(e.NewTextValue, RangeRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
			((Entry)sender).TextColor = isNoVailid ? Color.Default : Color.Red;
		}
	}
}
