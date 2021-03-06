﻿using System;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.ViewModels.Commits;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public CommitsController(IValidator validator, ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var currentRepo = this.data.Repositories
                .Where(r => r.Id == id)
                .FirstOrDefault();

            if (currentRepo == null)
            {
                return BadRequest();
            }

            return View(currentRepo);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateCommitFormModel model)
        {
            var errors = this.validator.ValidateCommitCreateModel(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            var commit = new Commit
            {
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = this.User.Id,
                RepositoryId = model.Id
            };

            this.data.Commits.Add(commit);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data.Commits
                .Where(c => c.CreatorId == this.User.Id)
                .Select(c => new CommitListingViewModel
                {
                    RepositoryName = c.Repository.Name,
                    CreatedOn = c.CreatedOn,
                    Description = c.Description
                })
                .ToList();

            return View(commits);
        }

        [Authorize]
        public HttpResponse Delete(string commitId)
        {
            var commit = this.data.Commits.FirstOrDefault(c => c.Id == commitId);

            if (commit == null || commit.CreatorId != this.User.Id)
            {
                return BadRequest();
            }

            this.data.Commits.Remove(commit);

            this.data.SaveChanges();

            return Redirect("/Commits/All");
        }
    }
}
