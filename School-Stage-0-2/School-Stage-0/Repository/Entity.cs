using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.Repository
{
    public abstract class Entity
    {
        private List<BusinessRule> brokenRules = new List<BusinessRule>();

        public int Id { get; set; }

        protected abstract void Validate();

        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            brokenRules.Clear();
            Validate();
            return brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            brokenRules.Add(businessRule);
        }

        public override bool Equals(object entity)
        {
            return entity != null
               && entity is Entity
               && this == (Entity)entity;

        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(Entity entity1, Entity entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Entity entity1,
            Entity entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}
