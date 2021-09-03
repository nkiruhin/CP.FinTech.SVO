using System.Collections.Generic;
using CP.FinTech.SVO.Core.ProjectAggregate;

namespace CP.FinTech.SVO.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
