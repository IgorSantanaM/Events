﻿using Events.IO.Application.Interfaces;
using Events.IO.Application.ViewModels;
using Events.IO.Domain.Core.Notifications;
using Events.IO.Domain.Interface;
using Events.IO.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Events.IO.Site.Controllers
{
    [Route("")]
    public class EventsController : BaseController
    {
        private readonly IEventAppService _eventAppService;

        public EventsController(IEventAppService eventAppService,
            IDomainNotificationHandler<DomainNotification> notifications, IUser user) : base(notifications, user)
        {
            _eventAppService = eventAppService;
        }
        [Route("")]
        [Route("Next-Events")]
        public IActionResult Index()
        {
            return View(_eventAppService.GetAll());
        }
        [Route("my-events")]
        [Authorize(Policy = "CanReadEvents")]
        public IActionResult MyEvents()
        {
            return View(_eventAppService.GetEventByHost(HostId));
        }
        [Route("details-of-the-event/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = _eventAppService.GetById(id.Value);
            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        [Route("new-event")]
        [Authorize(Policy = "CanAddEvents")]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("new-event")]
        [Authorize(Policy = "CanAddEvents")]
<<<<<<< HEAD
<<<<<<< HEAD
        public IActionResult Create(EventViewModel eventViewModel)
        {
             if (!ModelState.IsValid) return View(eventViewModel);

                eventViewModel.HostId = HostId;

                _eventAppService.Registry(eventViewModel);

                ViewBag.PostReturn = ValidateOperation() ? "success,Event registred!" : "error,Event was not registred verify the messages!";
=======

=======
>>>>>>> master
        public IActionResult Create(EventViewModel eventViewModel)
        {
             if (!ModelState.IsValid) return View(eventViewModel);

                eventViewModel.HostId = HostId;

                _eventAppService.Registry(eventViewModel);

<<<<<<< HEAD
>>>>>>> TesteApi
=======
                ViewBag.PostReturn = ValidateOperation() ? "success,Event registred!" : "error,Event was not registred verify the messages!";
>>>>>>> master
            return View(eventViewModel);
        }
        [Route("edit-event/{id:guid}")]
        [Authorize(Policy = "CanAddEvents")]

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = _eventAppService.GetById(id.Value);

            if (eventViewModel == null)
            {
                return NotFound();
            }
            if (ValidateAuthorEvent(eventViewModel))
            {
                return RedirectToAction("MyEvents", _eventAppService.GetEventByHost(HostId));
            }
            if (eventViewModel == null)
            {
                return NotFound();
            }
            return View(eventViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit-event/{id:guid}")]
        [Authorize(Policy = "CanAddEvents")]
<<<<<<< HEAD
<<<<<<< HEAD
=======


>>>>>>> TesteApi
=======
>>>>>>> master
        public IActionResult Edit(EventViewModel eventViewModel)
        {
            if (ValidateAuthorEvent(eventViewModel))
            {
                return RedirectToAction("MyEvents", _eventAppService.GetEventByHost(HostId));
            }
            if (!ModelState.IsValid) return View(eventViewModel);

            eventViewModel.HostId = HostId;
            _eventAppService.Update(eventViewModel);

<<<<<<< HEAD
<<<<<<< HEAD
            ViewBag.PostReturn = ValidateOperation() ? "success,Event updated!" : "error,Event was not updated verify the messages!";
=======
            ViewBag.PostReturn = ValidOperation() ? "success,Event updated!" : "error,Event was not updated verify the messages!";
>>>>>>> TesteApi
=======
            ViewBag.PostReturn = ValidateOperation() ? "success,Event updated!" : "error,Event was not updated verify the messages!";
>>>>>>> master

            if (_eventAppService.GetById(eventViewModel.Id).Online) {
                eventViewModel.Address = null;
            }
            else
            {
                eventViewModel = _eventAppService.GetById(eventViewModel.Id);
            }
                

            return View(eventViewModel);
        }
        [Authorize(Policy = "CanAddEvents")]
        [Route("delete-event/{id:guid}")]
<<<<<<< HEAD
<<<<<<< HEAD
=======

>>>>>>> TesteApi
=======
>>>>>>> master
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventViewModel = _eventAppService.GetById(id.Value);
            
            if (ValidateAuthorEvent(eventViewModel))
            {
                return RedirectToAction("MyEvents", _eventAppService.GetEventByHost(HostId));
            }

            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }
        [Authorize(Policy = "CanAddEvents")]
        [HttpPost, ActionName("Delete")]
        [Route("delete-event/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            if (ValidateAuthorEvent(_eventAppService.GetById(id)))
            {
                return RedirectToAction("MyEvents", _eventAppService.GetEventByHost(HostId));
            }
            _eventAppService.Delete(id);
            return RedirectToAction("Index");
        }
        [Route("include-address/{id:guid}")]
        [Authorize(Policy = "CanAddEvents")]
        public IActionResult IncludeAddress(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var eventViewModel = _eventAppService.GetById(id.Value);
            return PartialView("_IncludeAddress", eventViewModel);
        }
        [Route("update-address/{id:guid}")]
        [Authorize(Policy = "CanAddEvents")]
        public IActionResult UpdateAddress(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eventViewModel = _eventAppService.GetById(id.Value);
            return PartialView("_UpdateAddress", eventViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("include-address/{id:guid}")]
        [Authorize(Policy = "CanAddEvents")]
        public IActionResult IncludeAddress(EventViewModel eventViewModel)
        {
            ModelState.Clear();
<<<<<<< HEAD
<<<<<<< HEAD


            eventViewModel.Address.EventId = eventViewModel.Id;
            _eventAppService.AddAddress(eventViewModel.Address);

            if (ValidateOperation())
=======
            eventViewModel.Address.EventId = eventViewModel.Id;
            _eventAppService.AddAddress(eventViewModel.Address);

            if (ValidOperation())
>>>>>>> TesteApi
=======


            eventViewModel.Address.EventId = eventViewModel.Id;
            _eventAppService.AddAddress(eventViewModel.Address);

            if (ValidateOperation())
>>>>>>> master
            {
                string url = Url.Action("GetAddress", "Events", new { id = eventViewModel.Id });
                return Json(new { success = true, url = url });
            }
            return PartialView("_IncludeAddress", eventViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("update-address/{id:guid}")]
        [Authorize(Policy = "CanAddEvents")]
        public IActionResult UpdateAddress(EventViewModel eventViewModel)
        {
            ModelState.Clear();
<<<<<<< HEAD
<<<<<<< HEAD

         _eventAppService.UpdateAddress(eventViewModel.Address);

            if (ValidateOperation())
=======
            _eventAppService.UpdateAddress(eventViewModel.Address);

            if (ValidOperation())
>>>>>>> TesteApi
=======

         _eventAppService.UpdateAddress(eventViewModel.Address);

            if (ValidateOperation())
>>>>>>> master
            {
                string url = Url.Action("GetAddress", "Events", new { id = eventViewModel.Id });
                return Json(new { success = true, url = url });
            }
            return PartialView("_UpdateAddress", eventViewModel);
        }
        [Route("list-address/{id:guid}")]
        public IActionResult GetAddress(Guid id)
        {
            return PartialView("_DetailsAddress", _eventAppService.GetById(id));
        }
        private bool ValidateAuthorEvent(EventViewModel eventViewModel)
        {
            return eventViewModel.HostId != HostId;
        }
    }
}