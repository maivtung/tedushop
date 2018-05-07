﻿using System;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using System.Linq;

namespace TeduShop.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        Post GetById(int id);

        IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow);

        void SaveChange();
    }

    public class PostService : IPostService
    {
        IPostRepository _postRepostory;
        IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepostory, IUnitOfWork unitOfWork)
        {
            this._postRepostory = postRepostory;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Post post)
        {
            _postRepostory.Add(post);
        }

        public void Delete(int id)
        {
            _postRepostory.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepostory.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow)
        {
            return _postRepostory.GetMultiPaging(x => x.Status ,out totalRow,page,pageSize);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postRepostory.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRepostory.GetSingleById(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepostory.Update(post);
        }
    }
}