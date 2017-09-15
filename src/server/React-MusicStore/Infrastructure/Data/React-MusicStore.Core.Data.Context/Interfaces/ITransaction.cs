using System;

namespace ReactMusicStore.Core.Data.Context.Interfaces
{
	public interface ITransaction : IDisposable
	{
		void Commit();
		void Rollback();
	}
}