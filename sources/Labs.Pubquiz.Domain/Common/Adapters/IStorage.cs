﻿using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Pubquiz.Domain.Common.Entities;

namespace Labs.Pubquiz.Domain.Common.Adapters
{
    public interface IStorage : IDisposable
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;

        TEntity Find<TEntity>(Guid id) where TEntity : class, IEntity;

        void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Remove<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        void Save();

        void Clear();
    }
}