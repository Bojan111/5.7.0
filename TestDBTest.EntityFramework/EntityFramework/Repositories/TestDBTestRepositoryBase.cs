using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace TestDBTest.EntityFramework.Repositories
{
    public abstract class TestDBTestRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TestDBTestDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        //private IDbContextProvider<TestDBTestDbContext> dbContextProvider;

        protected TestDBTestRepositoryBase(IDbContextProvider<TestDBTestDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //protected TestDBTestRepositoryBase(IDbContextProvider<TestDBTestDbContext> dbContextProvider1)
        //{
        //    this.dbContextProvider1 = dbContextProvider1;
        //}


        //protected  TestDBTestRepositoryBase(IDbContextProvider<TestDBTestDbContext> dbContextProvider) :dbContextProvider
        //{ 

        //}

        //add common methods for all repositories
    }

    public abstract class TestDBTestRepositoryBase<TEntity> : TestDBTestRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected TestDBTestRepositoryBase(IDbContextProvider<TestDBTestDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
