
using System;
using System.Collections.Generic;

namespace gollum.web.common.Models
{
    public class BaseModel
    {
        public Guid Key { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
