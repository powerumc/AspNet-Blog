using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Umc.Core.Modules.Category.Model
{
	public interface ICategory
	{
		void Bind( Control control );
		CategoryNodeValue NodeValue { get; }
	}
}
