using Scrumptious.Data;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Data
{
   public class SprintTests
    {
        private Sprint sut; 

        private readonly MockContext mock = new MockContext();
        private readonly EntityData entity = new EntityData();
        private readonly scrumptiousdbContext ctx = new scrumptiousdbContext();

        public SprintTests()
        {
            sut = new Sprint()
            {
                Name = "Sprint 2",
                SprintDescription = "3 weeks to finish the rocket to the sun",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1),
                Completed = false,
                Backlog = new List<Backlog>() { new Backlog() },
                FkProjectId = 2,
                FkProject = entity.ReadList<Project>(2) //needs this
            };


            sut.AddBacklog(new Backlog());
            
        }

        //[Fact]
        //public void Test_SprintId()
        //{
        //    Sprint sp2 = new Sprint();
        //    mock.SaveAsync(sut);
        //    mock.SaveAsync(sp2);
        //    Assert.True(sut.SprintId != sp2.SprintId);
        //    Assert.True(typeof(int) == sut.SprintId.GetType());
        //}

        //[Fact]
        //public void Test_Sprint_Save_Mock()
        //{
        //    Sprint sut3 = new Sprint()
        //    {
        //        Name = "Sprint 2",
        //        SprintDescription = "3 weeks to finish the rocket to the sun",
        //        StartDate = DateTime.Now,
        //        EndDate = DateTime.Now.AddMonths(1),
        //        Completed = false,
        //        SprintId = 25,
        //        Backlog = new List<Backlog>() { new Backlog() },
        //        FkProjectId = 2,
        //        FkProject = null //needs this
        //    };
            
        //    mock.SaveAsync(sut);
        //    var actual = mock.Sprint.Count();

        //    Assert.True(1 <= actual);

        //}

        [Fact]
        public void Test_Sprint_Read_Mock()
        {
            Sprint sut2 = new Sprint()
            {
                Name = "Sprint 2",
                SprintDescription = "3 weeks to finish the rocket to the sun",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1),
                Completed = false,
                Backlog = new List<Backlog>() { new Backlog() },
                FkProjectId = 2,
                FkProject = null //needs this
            };
            mock.SaveAsync(sut2);
            var expected = sut2.SprintId;
            var actual = mock.ReadList<Sprint>(sut2.SprintId);
            Assert.Equal(expected, actual.SprintId);
        }
    }
}
