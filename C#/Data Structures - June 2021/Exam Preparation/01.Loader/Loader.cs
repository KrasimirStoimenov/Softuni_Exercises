namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader()
            => this.entities = new List<IEntity>();

        public int EntitiesCount => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Clear()
        {
            this.entities.Clear();
        }

        public bool Contains(IEntity entity)
        {
            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i] == entity)
                {
                    return true;
                }
            }

            return false;
        }

        public IEntity Extract(int id)
        {
            var entity = this.entities.Find(e => e.Id == id);
            if (entity != null)
            {
                this.entities.Remove(entity);
            }

            return entity;
        }

        public IEntity Find(IEntity entity)
            => this.entities.Find(e => e == entity);

        public List<IEntity> GetAll()
            => this.entities;

        public IEnumerator<IEntity> GetEnumerator()
            => this.entities.GetEnumerator();

        public void RemoveSold()
        {
            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Status == BaseEntityStatus.Sold)
                {
                    this.entities.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            var indexOfOldEntity = this.entities.IndexOf(oldEntity);
            this.CheckIfEntityExist(indexOfOldEntity);

            this.entities[indexOfOldEntity] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            var inBounds = new List<IEntity>();

            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Status >= lowerBound && this.entities[i].Status <= upperBound)
                {
                    inBounds.Add(entities[i]);
                }
            }

            return inBounds;
        }

        public void Swap(IEntity first, IEntity second)
        {
            var indexOfFirst = this.entities.IndexOf(first);
            this.CheckIfEntityExist(indexOfFirst);
            var indexOfSecond = this.entities.IndexOf(second);
            this.CheckIfEntityExist(indexOfSecond);

            var temp = this.entities[indexOfFirst];
            this.entities[indexOfFirst] = this.entities[indexOfSecond];
            this.entities[indexOfSecond] = temp;
        }

        public IEntity[] ToArray()
            => this.entities.ToArray();

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i].Status == oldStatus)
                {
                    this.entities[i].Status = newStatus;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void CheckIfEntityExist(int index)
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Entity not found");
            }
        }
    }
}
