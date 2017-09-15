using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactMusicStore.Core.Utilities.Infrastructure
{
	public interface IOrdered
	{
		// TODO: (MC) Make Nullable!
		int? Ordinal { get; }
	}
}
