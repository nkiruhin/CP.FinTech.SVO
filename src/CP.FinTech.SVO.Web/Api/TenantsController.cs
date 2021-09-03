﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP.FinTech.SVO.Core.ProjectAggregate;
using CP.FinTech.SVO.Core.ProjectAggregate.Specifications;
using CP.FinTech.SVO.SharedKernel.Interfaces;
using CP.FinTech.SVO.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CP.FinTech.SVO.Web.Api
{
    /// <summary>
    /// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
    /// https://github.com/ardalis/ApiEndpoints
    /// </summary>
    public class TenantsController : BaseApiController
    {
        private readonly IRepository<Project> _repository;

        public TenantsController(IRepository<Project> repository)
        {
            _repository = repository;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var projectDTOs = (await _repository.ListAsync())
                .Select(project => new TenantsDto
                {
                    Id = project.Id,
                    Name = project.Name
                })
                .ToList();

            return Ok(projectDTOs);
        }

        // GET: api/Projects
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(id);
            var project = await _repository.GetBySpecAsync(projectSpec);

            var result = new TenantsDto
            {
                Id = project.Id,
                Name = project.Name,
               
            };

            return Ok(result);
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TenantsDto request)
        {
            var newProject = new Project(request.Name);

            var createdProject = await _repository.AddAsync(newProject);

            var result = new TenantsDto
            {
                Id = createdProject.Id,
                Name = createdProject.Name
            };
            return Ok(result);
        }

        // PATCH: api/Projects/{projectId}/complete/{itemId}
        [HttpPatch("{projectId:int}/complete/{itemId}")]
        public async Task<IActionResult> Complete(int projectId, int itemId)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var toDoItem = project.Items.FirstOrDefault(item => item.Id == itemId);
            if (toDoItem == null) return NotFound("No such item.");

            toDoItem.MarkComplete();
            await _repository.UpdateAsync(project);

            return Ok();
        }
    }
}