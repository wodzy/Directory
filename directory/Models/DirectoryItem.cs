using System;
namespace directoryApi.Models
{
    public class DirectoryItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public bool isPrivate { get; set; }
        
    }
}