﻿using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete
{
    //?? deger null gelirse yapmak istediğimiz işlemi anlatır.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _efCategoryRepository;
        private EfCommentRepository _efCommentRepository;
        private EfRoleRepository _efRoleRepository;
        private EfUserRepository _efUserRepository;

        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }
        public IArticleRepository Articles => _articleRepository ?? new EfArticleRepository(_context);
        public ICategoryRepository Categories => _efCategoryRepository ?? new EfCategoryRepository(_context);
        public ICommentRepository Comments => _efCommentRepository ?? new EfCommentRepository(_context);
        public IRoleRepository Roles => _efRoleRepository ?? new EfRoleRepository(_context);
        public IUserRepository Users => _efUserRepository ?? new EfUserRepository(_context);
        
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
