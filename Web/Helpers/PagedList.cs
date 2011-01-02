using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Collections.Generic {
    public interface IPagedList {
        int TotalCount {
            get;
            set;
        }
        int CurrentPage {
            get;
        }
        int NextPage {
            get;
        }
        int LastPage {
            get;
        }
        int TotalPages {
            get;
            set;
        }
        int PageIndex {
            get;
            set;
        }

        int PageSize {
            get;
            set;
        }

        bool HasPreviousPage {
            get;
        }

        bool HasNextPage {
            get;
        }
        bool IsCurrentPage(int pageNumber);
    }

    public class PagedList<T> : List<T>, IPagedList {
        public PagedList(IQueryable<T> source, int index, int pageSize) {
            this.TotalCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.TotalPages = 1;
            CalcPages();

            this.AddRange(source.AsEnumerable().Skip(index * pageSize).Take(pageSize).ToList());
        }
        void CalcPages() {
            if (PageSize > 0 && TotalCount > PageSize) {
                TotalPages = TotalCount / PageSize;
                if (TotalCount % PageSize > 0)
                    TotalPages++;
            }
        }
        public int CurrentPage {
            get {
                return PageIndex + 1;
            }
        }
        public int NextPage {
            get {
                return CurrentPage + 1;
            }
        }
        public int LastPage {
            get {
                return CurrentPage - 1;
            }
        }
        public int TotalCount {
            get;
            set;
        }
        public int TotalPages {
            get;
            set;
        }
        public int PageIndex {
            get;
            set;
        }

        public int PageSize {
            get;
            set;
        }

        public bool HasPreviousPage {
            get {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage {
            get {
                return (PageIndex * PageSize) <= TotalCount;
            }
        }
        public bool IsCurrentPage(int pageNumber) {
            return pageNumber == CurrentPage;
        }
    }

    public static class Pagination {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize) {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index) {
            return new PagedList<T>(source, index, 10);
        }
    }
}
 
