﻿namespace Events.IO.Domain.DEvents.Commands
{
    public class UpdateEventCommand : BaseEventCommand
    {
        public UpdateEventCommand(Guid id, string name,string shortDesc, string longDesc, DateTime beginDate, DateTime endDate, bool free, decimal price, bool online, string companyName, Guid hostId ,Guid categoryId)
        {
			id = id;
			Name = name;
			ShortDescription = shortDesc;
			LongDescription = longDesc;
			BeginDate = beginDate;
			EndDate = endDate;
			Free = free; 
			Price = price;
			Online = online;
			CompanyName = companyName;
			HostId = hostId;
			CategoryId = categoryId;
		}
       
    }
}
