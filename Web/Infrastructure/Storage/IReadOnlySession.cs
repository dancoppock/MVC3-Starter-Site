using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure.Storage {
    public interface IReadOnlySession {

        T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new();
        System.Linq.IQueryable<T> All<T>() where T : class, new();

    }
}
