using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Labs.Pubquiz.Domain.Common.Adapters;
using Labs.Pubquiz.Domain.Common.Entities;
using GamesMaps = Labs.Pubquiz.Storage.Efw.Mappings.Games;
using QuestionsMaps = Labs.Pubquiz.Storage.Efw.Mappings.Questions;
using SecurityMaps = Labs.Pubquiz.Storage.Efw.Mappings.Security;

namespace Labs.Pubquiz.Storage.Efw.Contexts
{
    public class SqlStorage : DbContext, IStorage
    {
        static SqlStorage()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SqlStorage>());
        }

        public SqlStorage()
            : base("Name=EntitiesContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity
        {
            return Set<TEntity>();
        }

        public TEntity Find<TEntity>(Guid id)
            where TEntity : class, IEntity
        {
            return Set<TEntity>().Find(id);
        }

        public void Add<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            Set<TEntity>().Add(entity);
        }

        public void Add<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                Set<TEntity>().Add(entity);
            }
        }

        public void Remove<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            Set<TEntity>().Remove(entity);
        }

        public void Remove<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                Set<TEntity>().Remove(entity);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new QuestionsMaps.QuestionMap());
            modelBuilder.Configurations.Add(new QuestionsMaps.AnswerMap());
            modelBuilder.Configurations.Add(new QuestionsMaps.TagMap());

            //modelBuilder.Configurations.Add(new GamesMaps.GameMap());
            //modelBuilder.Configurations.Add(new GamesMaps.RoundMap());
            //modelBuilder.Configurations.Add(new GamesMaps.PlayerMap());
            //modelBuilder.Configurations.Add(new GamesMaps.QuestionMap());
            //modelBuilder.Configurations.Add(new GamesMaps.AnswerMap());
            //modelBuilder.Configurations.Add(new GamesMaps.PickMap());

            //modelBuilder.Configurations.Add(new SecurityMaps.UserMap());
            //modelBuilder.Configurations.Add(new SecurityMaps.RoleMap());
        }

        public void Save()
        {
            SaveChanges();
        }

        public void Clear()
        {
            Database.ExecuteSqlCommand("delete from [questions].Answer");
            Database.ExecuteSqlCommand("delete from [questions].QuestionTag");
            Database.ExecuteSqlCommand("delete from [questions].Question");
            Database.ExecuteSqlCommand("delete from [questions].Tag");
        }
    }
}