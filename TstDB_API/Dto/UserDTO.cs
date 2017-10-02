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
        public string Id_IdentityUser { get; set; }
        public DateTime CreationDate { get; set; }
        public IdentityUser Name { get { return this.Name; } set { Name = value; } } //Return name too, which is inside IdentityUser object!
    }
}