﻿
using EasyServer.Domain.Exceptions;
using EasyServer.Domain.Models;
using EasyServer.Domain.SearchModels;
using QTech.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using datasx = System.Data;

namespace QTech.Db
{
    public class MasterLogic
    {
        public QTechDbContext _db;
    }

    public class TDbLogic<T, TKey, TSelf> : MasterLogic
                where T : QTech.Base.TBaseModel<TKey>
                where TKey : struct
                where TSelf : TDbLogic<T, TKey, TSelf>, new()
    {

        public static TSelf Instance
        {
            get
            {
                var _ins = new TSelf();
                var ins = _ins as MasterLogic;
                ins._db = new QTechDbContext();
                return _ins;
            }
        }

        public static TSelf GetInstance(QTechDbContext db)
        {
            var _ins = new TSelf();
            var ins = _ins as MasterLogic;
            ins._db = db;
            return _ins;
        }

        public virtual IQueryable<T> All()
        {
            // For active column will override in in DbLogic
            return _db.Set<T>().AsNoTracking();
        }
        public virtual IQueryable<T> Search(ISearchModel model)
        {
            return All();
        }
        public virtual async Task<List<T>> SearchAsync(ISearchModel model)
        {
            return await All().ToListAsync();
        }
        public virtual T FindAsync(TKey id)
        {
            return null;

        }
        public virtual async Task<T> AddAsync(T entity)
        {
            if (await IsExistsAsync(entity))
            {
                throw new UniqueException(model: entity);
            }
            _db.Entry(entity).State = EntityState.Detached;
            entity.RowDate = DateTime.Now;
            SetActive(entity, true);
            _db.Entry(entity).State = EntityState.Added;
            await _db.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                if (await IsExistsAsync(entity))
                {
                    throw new UniqueException(model: entity);
                }

                _db.Entry(entity).State = EntityState.Modified;
                entity.RowDate = DateTime.Now;
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<T> RemoveAsync(TKey id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            if (!await CanRemoveAsync(entity))
            {
                throw new InusedException(model: entity);
            }
            return await RemoveAsync(entity);
        }
        public virtual async Task<T> RemoveAsync(T entity)
        {
            SetActive(entity, false);
            _db.Entry(entity).State = EntityState.Modified;
            entity.RowDate = DateTime.Now;
            await _db.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<bool> CanRemoveAsync(TKey id)
        {
            var entity = FindAsync(id);
            return await CanRemoveAsync(entity);
        }
        public virtual async Task<bool> CanRemoveAsync(T entity)
        {
            return await Task.FromResult(true);
        }
        public virtual async Task<bool> IsExistsAsync(T entity)
        {
            return await Task.FromResult(false);
        }
        public virtual async Task<T> GetEntityAsync(T entity)
        {
            return await Task.FromResult<T>(entity);
        }
        public virtual async Task<T> GetOldEntityAsync(T entity)
        {
            var oldEntity = await _db.Set<T>().FindAsync(entity.Id);
            _db.Entry(oldEntity).State = EntityState.Detached;
            return await Task.FromResult<T>(oldEntity);
        }

        private void SetActive(T obj, bool active)
        {
            var pi = typeof(T).GetProperties().FirstOrDefault(x => x.Name == "Active");
            if (pi == null) { return; } // no active field
            pi.SetValue(obj, active);
        }
    }
    public class DbLogic<T, TSelf> : TDbLogic<T, int, TSelf>
       where T : Base.ActiveBaseModel
        where TSelf : DbLogic<T, TSelf>, new()
    {
        public override IQueryable<T> All()
        {
            return _db.Set<T>().AsNoTracking().Where(x => x.Active);
        }
    }
}