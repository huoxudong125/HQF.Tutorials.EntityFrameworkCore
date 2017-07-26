using HQF.Daily.Web.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.DAL
{
    public class DailyDbContextInitializer
    {
        public static void Initialize(DailyDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Projects.Any())
                return;
                
            var project = new Project() { Name = "汾平高速" };


            context.Projects.Add(project);



            WorkArea workArea = new WorkArea() { Name = "工区一", Project = project };
            context.WorkAreas.Add(workArea);

            context.SaveChanges();

            var workTypeBridge = new WorkType() { Name = "桥梁" };
            var workTypeBridgeFirstStep = new WorkType { Name = "开挖" ,ParentWorkType=workTypeBridge};

            context.WorkTypes.Add(workTypeBridge);
            context.WorkTypes.Add(workTypeBridgeFirstStep);

            context.SaveChanges();


            var workUnit = new WorkUnit { Name="立方米"};
            context.WorkUnits.Add(workUnit);


            var bridgeWorkUnit1 = new WorkTypeUnit() { WorkTypeId = workTypeBridgeFirstStep.Id, WorkUnitId = workUnit.Id };
            context.WorkTypeUnits.Add(bridgeWorkUnit1);

            context.SaveChanges();

            var workTeam = new WorkTeam() { Name="杜村建工一局"};

            context.WorkTeams.Add(workTeam);

            var workitem = new WorkItem() { Name = "平遥杜村一桥", WorkArea = workArea, WorkType = workTypeBridge };
            var subWorkitem = new WorkItem() { Name = "平遥杜村一桥 开挖", WorkArea = workArea,  WorkType = workTypeBridgeFirstStep,ParentWorkItem=workitem };

            context.WorkItems.Add(workitem);
            context.WorkItems.Add(subWorkitem);

            context.SaveChanges();



            var workItemPrice = new WorkItemPrice() { WorkTeam = workTeam,WorkTypeUnit= bridgeWorkUnit1 };

            context.WorkItemPrices.Add(workItemPrice);

            context.SaveChanges();

            var workItemProgess = new WorkItemProgress() {CurrentDate=DateTime.Parse("2017-07-01"), WorkItemPrice = workItemPrice,  WorkQuantity = 10 };

            context.WorkItemProgresses.Add(workItemProgess);

            context.SaveChanges();
            
        }


    }
}
