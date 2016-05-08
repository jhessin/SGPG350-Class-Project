// ========================================================
// 
//   File Name:   MultiFormContext.cs
// 
//   Author:  Jim Hessin
// 
//   Course and Assignment:   SGPG440 - MultiDebug
// 
//   Description:  Describe what is contained in the file
// 
// =========================================================

using System.Threading;
using System.Windows.Forms;

namespace MultiDebug
{
	public class MultiFormContext : ApplicationContext
	{
		private int openForms;

		public MultiFormContext(params Form[] forms)
		{
			openForms = forms.Length;

			foreach (var form in forms)
			{
				form.FormClosed += (s, args) =>
				{
					if (Interlocked.Decrement(ref openForms) == 0)
					{
						ExitThread();
					}
				};
				form.Show();
			}
		}
	}
}