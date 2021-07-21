using QTech.Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Db.Logics
{
    public class UserLogic : DbLogic<User,UserLogic>
    {
        public override bool CanRemoveAsync(int id)
        {
            return _db.Users.Any(x => x.Id == id && x.Id != 0);
        }
        public override User AddAsync(User entity)
        {
            entity.PasswordHash = CalculateHash(entity.FullName, entity.PasswordHash);
            var result = base.AddAsync(entity);
            if (entity.UserPermissions.Any())
            {
                entity.UserPermissions.ForEach(x => {
                    x.UserId = result.Id;
                    UserPermissionLogic.Instance.AddAsync(x);
                });
            }
            return result;
        }

        public override User UpdateAsync(User entity)
        {
            if (string.IsNullOrEmpty(entity.PasswordHash))
            {
                _db.Entry(entity).State = EntityState.Modified;
                _db.Entry(entity).Property(x => x.PasswordHash).IsModified = false;
                entity.RowDate = DateTime.Now;
                _db.SaveChanges();
            }
            else
            {
                entity.PasswordHash = CalculateHash(entity.FullName, entity.PasswordHash);
                _db.Entry(entity).State = EntityState.Modified;
                entity.RowDate = DateTime.Now;
                _db.SaveChanges();
            }

            if (entity.UserPermissions.Any())
            {
                entity.UserPermissions.ForEach(x => {
                    if (x.Id == 0)
                    {
                        x.UserId = entity.Id;
                        UserPermissionLogic.Instance.AddAsync(x);
                    }
                    else
                    {
                        UserPermissionLogic.Instance.UpdateAsync(x);
                    }
                });
            }
            return entity;
        }
        public override User RemoveAsync(User entity)
        {
            var result =  base.RemoveAsync(entity);
            if (entity.UserPermissions.Any())
            {
                entity.UserPermissions.ForEach(x => {
                    UserPermissionLogic.Instance.RemoveAsync(x);
                });
            }
            return result;
        }
        public User GetUserByNameAndPassword(string fullName, string password)
        {
            var hashPassword = CalculateHash(fullName, password);
            return _db.Users.FirstOrDefault(x => x.PasswordHash == hashPassword && x.FullName == fullName);
        }
        public string CalculateHash(string userName, string password)
        {
            var tmp = $"{userName}QTech{password}";
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(tmp));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
