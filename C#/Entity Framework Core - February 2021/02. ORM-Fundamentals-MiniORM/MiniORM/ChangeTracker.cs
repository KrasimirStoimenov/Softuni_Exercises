using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
    // TODO: Create your ChangeTracker class here.
    internal class ChangeTracker<T> where T : class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.allEntities = CloneEntities(entities);
            this.added = new List<T>();
            this.removed = new List<T>();
        }

        public IReadOnlyCollection<T> AllEntities => this.allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();

        private List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntites = new List<T>();
            var propertiesToClone = typeof(T)
                .GetProperties()
                .Where(x => DbContext.AllowedSqlTypes.Contains(x.PropertyType))
                .ToArray();

            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();

                foreach (var property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }

                clonedEntites.Add(clonedEntity);
            }

            return clonedEntites;
        }

        public void Add(T item)
        {
            this.added.Add(item);
        }

        public void Remove(T item)
        {
            this.removed.Remove(item);
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbset)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T)
                .GetProperties()
                .Where(p => p.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var currentEntity in this.allEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, currentEntity).ToArray();

                var entity = dbset.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

                var isModified = IsModified(currentEntity, entity);
                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private static bool IsModified(T entity, T proxyEntity)
        {
            var monitoredProperties = typeof(T)
                .GetProperties()
                .Where(x => DbContext.AllowedSqlTypes.Contains(x.PropertyType));

            var modifiedProperties = monitoredProperties
                .Where(x => !Equals(x.GetValue(entity), x.GetValue(proxyEntity)))
                .ToArray();

            var isModified = modifiedProperties.Any();

            return isModified;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }
    }
}