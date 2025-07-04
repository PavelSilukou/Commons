using System;

namespace Commons.Intersection2D.Internal.Forms
{
	internal abstract class Form
	{
		private Form? _trueForm;
		protected virtual void OptionalValidation() {}

		protected virtual Form OverrideTrueForm()
		{
			return this;
		}

		public bool IsValid()
		{
			OptionalValidation();
			CheckTrueForm();
			return true;
		}
		
		public Form GetTrueForm()
		{
			if (_trueForm != null) return _trueForm;
			_trueForm = OverrideTrueForm();
			return _trueForm;
		}

		private void CheckTrueForm()
		{
			var trueForm = GetTrueForm();
			if (trueForm.GetType() != GetType()) throw new ArithmeticException($"Values form a {trueForm.GetType().Name}, not a {GetType().Name}.");
		}
	}
}