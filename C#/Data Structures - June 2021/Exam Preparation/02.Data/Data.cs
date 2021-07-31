namespace _02.Data
{
    using _02.Data.Interfaces;
    using System;
using System.Collections;
    using System.Collections.Generic;

    public class Data : IRepository
    {
        private PriorityQueue<IEntity> queue;
        private Dictionary<int, IEntity> dict;
        private Dictionary<int, List<IEntity>> parent;

        public Data()
        {
            this.queue = new PriorityQueue<IEntity>();
            this.dict = new Dictionary<int, IEntity>();
            this.parent = new Dictionary<int, List<IEntity>>();
        }

        public Data(PriorityQueue<IEntity> queue, Dictionary<int, IEntity> dict, Dictionary<int, List<IEntity>> parent)
        {
            this.queue = queue;
            this.dict = dict;
            this.parent = parent;
        }

        public int Size => this.queue.Size;

        public void Add(IEntity entity)
        {
            this.queue.Add(entity);
            this.dict.Add(entity.Id, entity);

            if (entity.ParentId != null)
            {
                if (!parent.ContainsKey((int)entity.ParentId))
                {
                    parent.Add((int)entity.ParentId, new List<IEntity>());
                }

                parent[(int)entity.ParentId].Add(entity);
            }
        }

        public IRepository Copy()
        {
            return new Data(this.queue, this.dict, this.parent);
        }

        public IEntity DequeueMostRecent()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }

            var element = queue.Dequeue();
            dict.Remove(element.Id);

            return element;
        }

        public List<IEntity> GetAll()
            => new List<IEntity>(this.queue.AsList);

        public List<IEntity> GetAllByType(string type)
        {
            if (type != "Invoice" && type != "StoreClient" && type != "User")
            {
                throw new InvalidOperationException("Invalid type: " + type);
            }

            var allByType = new List<IEntity>();
            var entities = queue.AsList;

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].GetType().Name == type)
                {
                    allByType.Add(entities[i]);
                }
            }

            return allByType;
        }

        public IEntity GetById(int id)
        {
            if (!dict.ContainsKey(id))
            {
                return null;
            }

            return dict[id];
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            if (!this.parent.ContainsKey(parentId))
            {
                return new List<IEntity>();
            }

            return parent[parentId];
        }

        public IEntity PeekMostRecent()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }
            return this.queue.Peek();
        }
    }
}
