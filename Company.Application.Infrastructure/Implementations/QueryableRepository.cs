namespace Company.Application.Infrastructure.Implementations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class QueryableRepository<T> : IQueryable<T> where T : class
    {
        /* ORM dependent (DbContext in entity framework, ISession in Nhibernate, etc.) */
        protected CoolDbContext context { get; set; }

        protected QueryableRepository(CoolDbContext context)
        {
            this.context = context;
        }

        public Type ElementType => this.context.Set<T>().AsQueryable().ElementType;

        public Expression Expression => this.context.Set<T>().AsQueryable().Expression;

        public IQueryProvider Provider => this.context.Set<T>().AsQueryable().Provider;

        public IEnumerator<T> GetEnumerator => this.context.Set<T>().AsQueryable().GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator;
        }
    }
}
