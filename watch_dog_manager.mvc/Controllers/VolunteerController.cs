using System;
using Microsoft.AspNetCore.Mvc;

namespace watch_dog_manager.mvc
{
	public class VolunteerController:Controller
	{
		[Route("volunteer")]
		public ViewResult Index()
		{
			return View("Search");
		}

		[Route("volunteer/manage")]
		public ViewResult Manage()
		{
			var viewModel = new ManageEntityViewModel();
			return View("Manage", viewModel);
		}

		[Route("volunteer/manage/{id}")]
		public ViewResult Manage(int id)
		{
			var viewModel = new ManageEntityViewModel { Id = id };
			return View("Manage",viewModel);
		}

	}
}
