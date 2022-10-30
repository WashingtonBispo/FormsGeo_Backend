using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FormsGeo.Service.User.Request
{
    public class ListUserGetRequest
    {
        [FromQuery]
        public string? filter { get; set; }
    }
}
