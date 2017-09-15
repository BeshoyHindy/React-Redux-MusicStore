using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactMusicStore.Core.Utilities.Common
{
	/// <summary>
	/// Allows action to be executed when it is disposed
	/// </summary>
	public struct ActionDisposable : IDisposable
	{
		readonly Action _action;

		public static readonly ActionDisposable Empty = new ActionDisposable(() => { });

		public ActionDisposable(Action action)
		{
			_action = action;
		}

		public void Dispose()
		{
			_action();
		}

	}

}
