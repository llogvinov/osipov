using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSVP
{
    public class ResponseRepository
    {
        private static ResponseRepository repository = new ResponseRepository();
        
        private List<GuestResponse> responses = new List<GuestResponse>();
        
        public static ResponseRepository GetRepository() => repository;
        
        public IEnumerable<GuestResponse> GetAllResponses() => responses;
        
        public void AddResponse(GuestResponse response) => responses.Add(response);
        
    }
}