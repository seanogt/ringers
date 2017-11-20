namespace ringerapi
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ringerapi;

    [Route("ringers")]
    public class RingersController
    {
        private readonly Func<List<Player>> _getRingers;

        public RingersController(Func<List<Player>> ringerRep)
        {
            this._getRingers = ringerRep;
        }

        [HttpGet]
        public Task<List<Player>> GetRingers()
        {
            return Task.Run(() => {return _getRingers();});
        }

    }
}