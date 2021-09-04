using CP.FinTech.SVO.Core.ProjectAggregate;
using CP.FinTech.SVO.Web.ApiModels;
using Xunit;

namespace CP.FinTech.SVO.UnitTests.Core.ProjectAggregate
{
    public class ProjectConstructor
    {
        private string _testName = "test name";
        private Tenant _testProject = null;

        private Tenant CreateProject()
        {
            return new Project(_testName);
        }

        [Fact]
        public void InitializesName()
        {
            _testProject = CreateProject();

            Assert.Equal(_testName, _testProject.Name);
        }

        [Fact]
        public void InitializesTaskListToEmptyList()
        {
            _testProject = CreateProject();

            Assert.NotNull(_testProject.Items);
        }

        [Fact]
        public void InitializesStatusToInProgress()
        {
            _testProject = CreateProject();

            Assert.Equal(ProjectStatus.Complete, _testProject.Status);
        }
    }
}
