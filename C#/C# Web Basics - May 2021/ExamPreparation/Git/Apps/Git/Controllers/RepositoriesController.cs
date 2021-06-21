﻿using System;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.ViewModels.Repositories;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public RepositoriesController(IValidator validator, ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create()
            => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateRepositoryViewModel model)
        {
            var errors = this.validator.ValidateCreateRepository(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == DataConstants.RepositoryTypePublic,
                CreatedOn = DateTime.UtcNow,
                OwnerId = this.User.Id
            };

            this.data.Repositories.Add(repository);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var currentUser = this.data.Users.FirstOrDefault(u => u.Id == this.User.Id);

            var repositories = this.data.Repositories
                .Where(r => r.IsPublic)
                .Select(r => new RepositoryListingViewModel
                {
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn,
                    CommitsCount = r.Commits.Count
                })
                .ToList();

            return View(repositories);
        }
    }
}
