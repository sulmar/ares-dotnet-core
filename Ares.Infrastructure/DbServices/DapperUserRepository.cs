using Ares.Domain.Models;
using Ares.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;

namespace Ares.Infrastructure.DbServices
{

    // dotnet add package Dapper
    public class DapperUserRepository : IUserRepository, IAuthorizationService
    {
        private readonly IDbConnection connection;

        public DapperUserRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            string sql = "select Users.*, Addresses.* from Users left outer join Addresses on Users.HomeAddressId = Addresses.AddressId";

            return connection.Query<User, Address, User>(sql, (user, address) =>
            {
                user.HomeAddress = address;

                return user;
            }, splitOn: "Id, AddressId")
                .ToList();

        }

        public User Get(int id)
        {
            // exec uspGetUser @Id = 100
            // create procedure uspGetUser(
            //  @Id int
            // )
            // as 
            // begin
            // select * from dbo.Users where Id = @Id
            // end


            string sql = "select Users.*, Addresses.* from Users left outer join Addresses on Users.HomeAddressId = Addresses.AddressId where id = @Id";

                return connection.Query<User, Address, User>(sql, (user, address) =>
                {
                    user.HomeAddress = address;

                    return user;
                }, 
             new { @Id = id })

                .FirstOrDefault();




            return connection.Query<User>("uspGetUser", new { @Id = id }, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();

            return connection.Query<User>("exec uspGetUser @Id", new { @Id = id })
              .FirstOrDefault();

        }

        public void Remove(int id)
        {

            throw new NotImplementedException();
        }

        public dynamic Test(int id)
        {
            return connection.Query("uspGetUser", new { @Id = id }, commandType: CommandType.StoredProcedure)
              .FirstOrDefault();
        }

        public bool TryAuthorize(string userId, string hashedPassword, out User user)
        {

            string sql = "exec uspUserAuthorize @UserId, @HashedPassword";

            user = connection.Query<User>(sql, new { @UserId = userId, @HashedPassword = hashedPassword })
                .SingleOrDefault();

            return user != null;
        }
    }
}
