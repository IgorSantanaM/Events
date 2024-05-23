﻿using System.ComponentModel.DataAnnotations;

namespace Events.IO.Application.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            Id = Guid.NewGuid();
            Address = new AddressViewModel();
            Category = new CategoryViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(2, ErrorMessage = "The min length of the name is {2}")]
        [MaxLength(150, ErrorMessage = "The max length of the name is {150}")]
        [Display(Name = "Event name.")]
        public string Name { get; set; }

        [Display(Name = "Short description of the event")]
        public string ShortDescription { get; set; }

        [Display(Name = "Long description of the event")]
        public string LongDescription { get;  set; }

        [Display(Name = "Beginning of the Event")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BeginDate { get;  set; }

        [Display(Name = "Ending of the Event")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Is it going to be free?")]
        public bool Free { get; set; }

        [Display(Name = "Value")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal Value { get; set; }

        [Display(Name = "Is it going to be Online?")]
        public bool Online { get; set; }

        [Display(Name = "Company / Host Group")]
        public string CompanyName { get; set; }
        public AddressViewModel Address { get; set; }
        public CategoryViewModel Category { get; set; }
        public Guid CategoryId { get; set; }
        public Guid HostId { get; set; }

    }
}