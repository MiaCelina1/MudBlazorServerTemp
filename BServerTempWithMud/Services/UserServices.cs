using BServerTempWithMud.Models;
using Microsoft.EntityFrameworkCore;

namespace BServerTempWithMud.Services
{
	public interface IUserServices
	{
		Task<MyUser[]> GetAllUser();
		Task<MyUser> Save(MyUser myUser);
	}

	public class UserServices : IUserServices
	{
		private readonly IDbContextFactory<MyDbContext> _dbContextFactory;

		public UserServices(IDbContextFactory<MyDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}
		public async Task<MyUser[]> GetAllUser()
		{
			using var context = await _dbContextFactory.CreateDbContextAsync();
			var res = await context.MyUsers.ToArrayAsync();
			return res;

		}
		public async Task<MyUser> Save(MyUser myUser)
		{
			using var Context = await _dbContextFactory.CreateDbContextAsync();
			if (myUser.UserId == 0)
			{
				// Add New Person
				await Context.MyUsers.AddAsync(myUser);
			}
			else
			{
				//Update Person

				var DbMinUser = await Context.MyUsers.AsTracking().FirstOrDefaultAsync(a => a.UserId == myUser.UserId);
				if (DbMinUser is null)
				{
					throw new InvalidOperationException("User Dos Not Exist!");
				}
				DbMinUser.UserName = myUser.UserName;


			}
			await Context.SaveChangesAsync();
			return myUser;
		}

	}
}
