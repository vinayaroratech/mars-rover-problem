using MarsRoverProblem.Api.Models;
using MarsRoverProblem.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MarsRoverProblem.Api.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public async Task<ActionResult> IndexAsync()
        {
            using HttpClient client = new();
            string endpoint = GetBaseUrl() + "/api/Positions";

            using var Response = await client.GetAsync(endpoint);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await Response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                ViewData["Result"] = result;
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Invalid Request");
                return View();

            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Moves,X,Y,Direction,MaxX,MaxY")] MovingRequestViewModel movingRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using HttpClient client = new();
                    string endpoint = GetBaseUrl() + "/api/Positions";
                    var content = new MovingRequestModel()
                    {
                        Direction = movingRequest.Direction,
                        MaxPoints = new List<int>() { movingRequest.MaxX, movingRequest.MaxY },
                        Moves = movingRequest.Moves,
                        X = movingRequest.X,
                        Y = movingRequest.Y
                    };

                    using var Response = await client.PostAsJsonAsync(endpoint, content);
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await Response.Content.ReadAsStringAsync();
                        ViewData["Result"] = result;
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, await Response.Content.ReadAsStringAsync());
                        return View(movingRequest);

                    }
                }
                return View(movingRequest);
            }
            catch
            {
                return View(movingRequest);
            }
        }

        private string GetBaseUrl()
        {
            var request = HttpContext.Request;

            var host = request.Host.ToUriComponent();

            var pathBase = request.PathBase.ToUriComponent();

            return $"{request.Scheme}://{host}{pathBase}";
        }
    }
}
