using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TstDB_API.Dto
{
    public class UserDTO 
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}